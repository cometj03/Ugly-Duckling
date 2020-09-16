using UnityEngine;

public class World01_Summer : MonoBehaviour
{
    public CameraValue cameraValue;

    [SerializeField] GameObject background = default;
    [SerializeField] GameObject hills = default;
    [SerializeField] GameObject cloud = default;
    [SerializeField] GameObject floor = default;

    private GameObject maincamera;
    private float floorWidth;//, hillsWidth, cloudWidth;
    private float hillsOffset, cloudOffset;

    void Start()
    {
        // 바닥 가로 길이
        floorWidth = floor.GetComponent<SpriteRenderer>().size.x * floor.transform.localScale.x;
        // hill 가로 길이
        //hillsWidth = hills.GetComponent<SpriteRenderer>().size.x * hills.transform.localScale.x;
        // 구름 가로 길이
        //cloudWidth = cloud.GetComponent<SpriteRenderer>().size.x * cloud.transform.localScale.x;

        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        hillsOffset = hills.transform.position.x - cameraValue.cameraTarget.x;
        cloudOffset = cloud.transform.position.x - cameraValue.cameraTarget.x;
    }

    void FixedUpdate()
    {
        // floor 반복
        float diff = maincamera.transform.position.x - floor.transform.position.x;
        if (diff >= floorWidth / 4)
            floor.transform.position += Vector3.right * floorWidth / 2;
        else if (diff <= -floorWidth / 4)
            floor.transform.position -= Vector3.right * floorWidth / 2;
        
        // 배경 움직임
        Vector3 bgPos = background.transform.position;
        bgPos.x = maincamera.transform.position.x;
        background.transform.position = bgPos;
        MoveBgObject(hills, hillsOffset, 0.5f);
        MoveBgObject(cloud, cloudOffset, 0.9f);
    }
    
    private void MoveBgObject(GameObject gameObject, float offset, float ratio)
    {
        Vector3 pos = gameObject.transform.position;
        pos.x = Mathf.Lerp(pos.x, cameraValue.cameraTarget.x * ratio + offset, CameraValue.SmoothSpeed);
        gameObject.transform.position = pos;
    }
}
