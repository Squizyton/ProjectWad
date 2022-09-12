using UnityEngine;
using UnityEngine.Serialization;

namespace Pickupables
{
    [System.Serializable]
    public abstract class Pickupable : MonoBehaviour,IPickupable
    {
        private bool _pickedUp = false;
        private Transform target;
    
        [SerializeField] private float speed = 1f;
        [SerializeField] private float distanceTillGoTo = 1f;
        [SerializeField]private BoxCollider2D objCollider;
        private Vector2 startPos;

        private bool hitendPoint;
        // Start is called before the first frame update
    
        void Start()
        {
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!_pickedUp) return;
        
            var distance = Vector2.Distance(transform.position, target.position);

            //move away from Target
            if(!hitendPoint && distance < distanceTillGoTo)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, - speed * Time.deltaTime);
            }
            else
            {
                hitendPoint = true;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
                if (distance < 0.1f)
                {
                    //Add to inventory
                    //TODO: Might want to change this to a ObjectPool
                    
                    OnPickup();
                }
            }
        }

        public abstract void OnPickup();
        public void Pickup(Transform gotoTarget)
        {
            objCollider.enabled = false;
            _pickedUp = true;
            target = gotoTarget;
        }
    }
}
