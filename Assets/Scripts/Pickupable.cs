using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour,IPickupable
{
    private bool _pickedUp = false;
    private Transform target;
    
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distanceTillGoTo = 1f;
    [SerializeField]private BoxCollider2D collider;
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
        if(!hitendPoint && distance < _distanceTillGoTo)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -_speed * Time.deltaTime);
        }
        else
        {
            hitendPoint = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            
            if (distance < 0.1f)
            {
                //Add to inventory
                //TODO: Might want to change this to a ObjectPool
                Destroy(gameObject);
            }
        }
    }
    
    
    
    
    public void Pickup(Transform gotoTarget)
    {
        collider.enabled = false;
        _pickedUp = true;
        target = gotoTarget;
    }
}
