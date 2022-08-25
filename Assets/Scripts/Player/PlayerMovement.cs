using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
    //Very Basic movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        
        transform.Translate(direction * (speed * Time.deltaTime));    
    }
}
