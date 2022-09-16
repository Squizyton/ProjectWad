using UnityEngine;

namespace Guns.Abilities.Bullet_Abilities.OnTick
{
    public class BaseTickAbility : BaseBulletAbility
    {
        
        
        private bool repeatResult = false;
        private float timer = 0;
        private float timerMax = 0;
        
        public BaseTickAbility(Transform bulletTransform,float time, bool repeat)
        {
           repeatResult = repeat;
           bullet = bulletTransform;
           timerMax = time;
           timer = timerMax;
        }


        public override void OnTick()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (!(timer <= 0)) return;
            
            if(repeatResult)
                timer = timerMax;
            
        }


        public override void OnHit(Collider2D hit)
        {
            throw new System.NotImplementedException();
        }

        public override void OnHit()
        {
            throw new System.NotImplementedException();
        }
        public override void OnMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
