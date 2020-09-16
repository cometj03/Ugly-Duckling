using UnityEngine;

public class SummerIdle : MonoBehaviour
{
    [SerializeField] GameObject cloud = default;

    Vector3 cloudVelocity = new Vector3(-0.1f, 0);
    private bool isCloudUp;

    private GameObject maincamera;
    private float cloudWidth, cloudPosY;

    private void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        
        cloudWidth = cloud.GetComponent<SpriteRenderer>().size.x * cloud.transform.localScale.x;
        cloudPosY = cloud.transform.position.y;
    }

    void Update()
    {
        // 구름 반복
        float diff = maincamera.transform.position.x - cloud.transform.position.x;
        if (diff >= cloudWidth / 4)
            cloud.transform.position += Vector3.right * cloudWidth / 2;
        else if (diff <= -cloudWidth / 4)
            cloud.transform.position -= Vector3.right * cloudWidth / 2;
        
        // 구름 위아래
        if (cloud.transform.position.y > cloudPosY + 0.2f) // down
            isCloudUp = false;
        else if (cloud.transform.position.y < cloudPosY - 0.2f) // up
            isCloudUp = true;

        cloudVelocity.y = isCloudUp ? 0.05f : -0.05f;
        cloud.transform.position += cloudVelocity * Time.deltaTime;
    }
}
