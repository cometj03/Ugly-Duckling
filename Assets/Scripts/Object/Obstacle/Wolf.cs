using UnityEngine;

public class Wolf : MonoBehaviour
{
    private float speed = 4f;
    private bool go = true;

    void Update()
    {
        if (go)
            transform.position += Vector3.right * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile"))
        {
            go = false;
            Destroy(gameObject);
        } else if (other.CompareTag("Player"))
        {
            go = false;
            GameManager.instance.GameOver();
        }
    }
}
