using UnityEngine;

public class AutumnIdle : MonoBehaviour
{
    
    [SerializeField] GameObject cloud = default;

    private GameObject maincamera;
    private float cloudWidth, cloudPosY;
    private bool isCloudUp = true;

    private Vector3 cloudVelocity;
    
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        // 오브젝트 가로
        cloudWidth = cloud.GetComponent<SpriteRenderer>().size.x * cloud.transform.localScale.x;
        
        cloudPosY = cloud.transform.position.y;
        
        cloudVelocity = new Vector3(-0.1f, 0, 0);
    }

    void Update()
    {
        RepeatObject(cloud, cloudWidth);

        // 구름 위아래
        if (cloud.transform.position.y > cloudPosY + 0.1f) // down
            isCloudUp = false;
        else if (cloud.transform.position.y < cloudPosY - 0.3f) // up
            isCloudUp = true;

        cloudVelocity.y = isCloudUp ? 0.1f : -0.1f;

        cloud.transform.position += cloudVelocity * Time.deltaTime;
    }

    private void RepeatObject(GameObject g, float width)
    {
        float diff = maincamera.transform.position.x - g.transform.position.x;
        if (diff >= width / 6)
            g.transform.position += Vector3.right * width / 3;
        else if (diff <= -width / 6)
            g.transform.position -= Vector3.right * width / 3;
    }
}
