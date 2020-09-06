using System;
using UnityEngine;

public class SummerIdle : MonoBehaviour
{
    [SerializeField] GameObject cloud = default;

    Vector3 cloudVelocity = new Vector3(-0.1f, 0);
    private bool isCloudUp;

    private float cloudWidth;

    private void Start()
    {
        cloudWidth = cloud.GetComponent<SpriteRenderer>().size.x * cloud.transform.localScale.x;
    }

    void Update()
    {
        // 구름 반복
        if (cloud.transform.position.x <= -cloudWidth / 4)
            cloud.transform.position += Vector3.right * cloudWidth / 2;
        
        // 구름 움직임
        if (cloud.transform.position.y > 1.1f) // down
            isCloudUp = false;
        else if (cloud.transform.position.y < 0.8f) // up
            isCloudUp = true;

        cloudVelocity.y = isCloudUp ? 0.05f : -0.05f;
        cloud.transform.position += cloudVelocity * Time.deltaTime;
    }
}
