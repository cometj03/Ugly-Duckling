using System;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private float speed = 4f;
    private bool go = true;
    private Transform _signTransform, _camTransform;

    private void Start()
    {
        _signTransform = FindObjectOfType<WolfSign>().transform;
        _camTransform = FindObjectOfType<CameraMovement>().transform;
    }

    void Update()
    {
        if (go)
            transform.position += Vector3.right * (speed * Time.deltaTime);
        else if (_camTransform.position.x - transform.position.x > 7)
        {
            FindObjectOfType<WolfSign>().isInstance = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile") && transform.position.x < _signTransform.position.x + 0.5f)
        {
            go = false;
        } else if (other.CompareTag("Player"))
        {
            go = false;
            other.GetComponent<BirdController>().BirdPush(45, 80);
            GameManager.instance.GameOver();
        }
    }
}
