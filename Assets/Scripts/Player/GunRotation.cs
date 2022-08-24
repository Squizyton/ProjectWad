using UnityEngine;

namespace Player
{
    public class GunRotation : MonoBehaviour
    {
        
        
        [SerializeField]private Transform player;
        [SerializeField]private Transform gun;
        [SerializeField] private Transform gunHolder;
        [SerializeField]private float _rotationSpeed;
        
        // Start is called before the first frame update
        // Update is called once per frame
        void Update()
        {
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //get the angle
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            var targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //rotate the gun
            gun.rotation = Quaternion.Slerp(gun.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            
            //move the gun around the player
            
            
        }
    }
}
