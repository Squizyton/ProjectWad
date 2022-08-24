using UnityEngine;

namespace Player
{
    public class GunRotation : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float offset;

        // Start is called before the first frame update
        // Update is called once per frame
        void Update()
        {
            RotateTheGun();
            CheckForScaleChange();
        }

        void RotateTheGun()
        {
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //get the angle
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            var targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        }

        void CheckForScaleChange()
        {
            transform.localScale = transform.rotation.z > 0 ? new Vector3(1, -1, 1) : new Vector3(1, 1, 1);
        }
    }
}