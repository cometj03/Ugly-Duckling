using System;
using System.Collections;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Transform _birdTransform;
    private Transform _camTransform;
    private bool isExplore, once;
    
    Vector3 beeVelocity = Vector3.right * -1f;
    
    
    void Start()
    {
        _birdTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void LateUpdate()
    {
        if (Mathf.Abs(_birdTransform.position.x - transform.position.x) > 3 || isExplore)
            return;
        
        if (_birdTransform.position.y > transform.position.y)
        {
            StartCoroutine(Searching());
        }
    }

    IEnumerator Searching()
    {
        isExplore = true;
        while (isExplore)
        {
            transform.position += beeVelocity * Time.deltaTime;
            
            if (_camTransform.position.x > transform.position.x + 8)    // 카메라 밖으로 나감
                Destroy(gameObject);
            
            yield return null;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        isExplore = false;
        if (other.CompareTag("Player"))
            GameManager.instance.GameOver();
    }
}
