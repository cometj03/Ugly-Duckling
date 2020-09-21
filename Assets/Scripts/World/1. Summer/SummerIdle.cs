using UnityEngine;

public class SummerIdle : MonoBehaviour
{
    [SerializeField] GameObject cloud = default;

    public Vector3 cloudVelocity = Vector3.zero;
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
        RepeatObject(cloud, cloudWidth);
        
        // 구름 위아래
        if (cloud.transform.position.y > cloudPosY + 0.2f) // down
            isCloudUp = false;
        else if (cloud.transform.position.y < cloudPosY - 0.2f) // up
            isCloudUp = true;

        cloudVelocity.y = isCloudUp ? 0.05f : -0.05f;

        if (PlayerData.Instance.currentState != GameState.CONTINUE)
            cloudVelocity.x = -0.1f;
        cloud.transform.position += cloudVelocity * Time.deltaTime;
    }
    
    private void RepeatObject(GameObject g, float width)
    {
        float diff = maincamera.transform.position.x - g.transform.position.x;
        if (diff >= width / 4)
            g.transform.position += Vector3.right * width / 2;
        else if (diff <= -width / 4)
            g.transform.position -= Vector3.right * width / 2;
    }
}
