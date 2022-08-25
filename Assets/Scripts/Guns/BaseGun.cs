using System;
using System.Collections;
using UnityEngine;

namespace Guns
//TODO make a gun controller at some point
{
    public abstract class BaseGun : MonoBehaviour
    {

        
       [SerializeField] private protected float fireRate;
       [SerializeField] private protected int magazineSize;
       [SerializeField] private protected int currentMagazine;
       [SerializeField] private protected float reloadTime;
       [SerializeField] private protected float accuracy;
        
        //Amount of bullets fired every shot
        [SerializeField]private protected int bulletAmount;

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
        }

        public virtual void Fire()
        {
            if(!_canFire) return;


            if (currentMagazine > 0)
            {
                _fireRateTimer = fireRate;
                currentMagazine--;
                Debug.Log("Firing");
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
            
            if(_fireRateTimer > 0)
            {
                _fireRateTimer -= Time.deltaTime;
            }
            else
            {
                _canFire = true;
            }
        }


        IEnumerator StartReload()
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
