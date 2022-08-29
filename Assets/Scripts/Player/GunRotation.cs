using System;
using UnityEngine;

namespace Player
{
    public class GunRotation : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float offset;
        [SerializeField]private Camera gameCamera;

        private static Camera staticCamera;
        private static Vector3 position;
        // Start is called before the first frame update
        // Update is called once per frame

        private void Start()
        {
            staticCamera = gameCamera;
            
        }

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
            position = transform.position;
        }

        void CheckForScaleChange()
        {
            transform.localScale = transform.rotation.z > 0 ? new Vector3(1, -1, 1) : new Vector3(1, 1, 1);
        }
        
        public static Vector3 GetMousePosition()
        {
            //TODO DONT USE CAMERA.MAIN. CHANGE THIS ASAP
            return staticCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        
        public static Vector3 GetGunPosition()
        {
            return position;
        }
    }
}