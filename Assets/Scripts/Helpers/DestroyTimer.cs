using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroy the object after a certain amount of time.
/// </summary>
public class DestroyTimer : MonoBehaviour
{
    
    [SerializeField] private float timeToDestroy = 1f;

    private WaitForSeconds _timer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = new WaitForSeconds(timeToDestroy);
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return _timer;
        Destroy(gameObject);
    }
}
