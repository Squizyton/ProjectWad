using System;
using System.Collections;
using System.Collections.Generic;
using Crafting;
using Guns.Abilities;
using Player;
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

        [SerializeField,ReadOnly] private protected int currentMagazine;
        
        [Title("Reload Time")]
        [SerializeField] private float reloadTime;
        
        [Title("Accuracy/Heat")]
        [SerializeField] private  float accuracy;

        [Title("Bullet Prefab")] [SerializeField]
        private Transform bulletSpawn;
        [SerializeField,ReadOnly] private GameObject bulletPrefab;
        [SerializeField] private BaseBullet bullet;


        [Title("Bullet Spawn Amount")]
        //Amount of bullets fired every shot
        [SerializeField] private protected int bulletAmount;

        private Action onFire;
        private Action onReload;
        private Action onEmpty;
        private Action onSwitch;


        //public variables
        public bool autoFire;


        //Private variables
        private bool _isReloading;
        private float _fireRateTimer;
        private float _reloadTimer;
        private bool _canFire;

        //Cache a waitforseconds for performance
        private WaitForSeconds _reloadWait;

        
        private List<AbilityStruct<BaseBulletAbility>> _bulletAbilities = new ();

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
                onFire?.Invoke();
                Shoot();
                _canFire = false;
            }
            else
            {
                //Make a reload click sound
            }
        }



        public void Shoot()
        {
               
            var spawnedBullet = Instantiate(bullet,bulletSpawn.transform.position, Quaternion.identity);
               
            foreach(var ability in _bulletAbilities)
            {
                spawnedBullet.InjectAbility(ability.ReturnType(),ability.ReturnAbility());
            }
            //rotate the bullet towards the mouse on z-axis
               
            //TODO: make this neater
            var mousePos = GunRotation.GetMousePosition();
            var direction = (mousePos - bulletSpawn.position).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
               
            spawnedBullet.transform.rotation =Quaternion.Euler(new Vector3(0,0,angle + 270));
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

        public void AddAbility(CraftingRecipe recipe)
        {
            if (!recipe.bullet) return;
            var ability = recipe as BulletCraftingRecipe;
            if (ability != null)
                _bulletAbilities.Add(new AbilityStruct<BaseBulletAbility>(ability.type, ability.bulletAbility));
        }


        [ContextMenu("Test Ability")]
        public void AddTestMovement()
        {
            _bulletAbilities.Add(new AbilityStruct<BaseBulletAbility>(AbilityType.Type.OnMove, new SlowFast(null,1)));
        }
    }

    public struct AbilityStruct<T>
    {
        private AbilityType.Type type;
        private T ability;
        
        
        public AbilityStruct(AbilityType.Type type, T ability)
        {
            this.type = type;
            this.ability = ability;
        }
        
        public AbilityType.Type ReturnType()
        {
            return type;
        }
        
        public T ReturnAbility()
        {
            return ability;
        }
    }
}