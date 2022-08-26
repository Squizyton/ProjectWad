using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Guns
//TODO make a gun controller at some point
{
    public abstract class BaseGun : MonoBehaviour
    {
        [Title("Fire Rate")] [SerializeField] private protected float fireRate;

        [Title("Magazine Size")] [SerializeField]
        private protected int magazineSize;

        [SerializeField] private protected int currentMagazine;
        
        [Title("Reload Time")]
        [SerializeField] private protected float reloadTime;
        
        [Title("Accuracy/Heat")]
        [SerializeField] private protected float accuracy;

        [Title("Bullet Prefab")] [SerializeField]
        private Transform bulletSpawn;
        [SerializeField] private protected GameObject bulletPrefab;
        [SerializeField,ReadOnly] private BaseBullet bullet;


        [Title("Bullet Spawn Amount")]
        //Amount of bullets fired every shot
        [SerializeField] private protected int bulletAmount;

        private protected Action onFire;
        private protected Action onReload;
        private protected Action onEmpty;
        private protected Action onSwitch;


        //public variables
        public bool autoFire;


        //Private variables
        private bool _isReloading;
        private float _fireRateTimer;
        private float _reloadTimer;
        private bool _canFire;

        //Cache a waitforseconds for performance
        private WaitForSeconds _reloadWait;

        private void Start()
        {
            _reloadWait = new WaitForSeconds(reloadTime);
            bullet = bulletPrefab.GetComponent<BaseBullet>();
        }

        public virtual void Fire()
        {
            if (!_canFire) return;


            if (currentMagazine > 0)
            {
                _fireRateTimer = fireRate;
                currentMagazine--;
                Debug.Log("Firing");
                onFire?.Invoke();
                
                Instantiate(bulletPrefab,bulletSpawn.transform.position);
                _canFire = false;
            }
            else
            {
                Debug.Log("Out of ammo");
            }
        }

        public virtual void Reload()
        {
            //async reload
            if (_isReloading || currentMagazine == magazineSize) return;

            _isReloading = true;

            //TODO switch to normal timer for UI purposes
            StartCoroutine(StartReload());
        }

        public virtual void Update()
        {
            if (_isReloading) return;

            if (_canFire) return;

            if (_fireRateTimer > 0)
            {
                _fireRateTimer -= Time.deltaTime;
            }
            else
            {
                _canFire = true;
            }
        }


        private IEnumerator StartReload()
        {
            //Event that is called when reloading
            onReload?.Invoke();


            yield return _reloadWait;
            _isReloading = false;
            var bulletAmountToAdd = magazineSize - currentMagazine;
            currentMagazine += bulletAmountToAdd;
        }
    }
}