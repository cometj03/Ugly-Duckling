using UnityEngine;

public class World01_Summer : MonoBehaviour
{
    public CameraValue cameraValue;

    [SerializeField] GameObject background = default;
    [SerializeField] GameObject hills = default;
    [SerializeField] GameObject cloud = default;
    [SerializeField] GameObject floor = default;

    private GameObject maincamera;
    private float floorWidth, hillsWidth, cloudWidth;
    private float hillsOffset, cloudOffset;

    void Start()
    {
        // 바닥 가로 길이
        floorWidth = floor.GetComponent<SpriteRenderer>().size.x * floor.transform.localScale.x;
        // 구름 가로 길이
        cloudWidth = cloud.GetComponent<SpriteRenderer>().size.x * cloud.transform.localScale.x;

        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        hillsOffset = hills.transform.position.x - cameraValue.backgroundTarget.x;
        cloudOffset = cloud.transform.position.x - cameraValue.backgroundTarget.x;
    }

    void FixedUpdate()
    {
        // 배경 반복
        RepeatObject(floor, floorWidth);
        
        // 배경 움직임
        Vector3 bgPos = background.transform.position;
        bgPos.x = maincamera.transform.position.x;
        background.transform.position = bgPos;
        MoveBgObject(hills, hillsOffset, 0.5f);
    }
    
    private void MoveBgObject(GameObject g, float offset, float ratio)
    {
        Vector3 pos = g.transform.position;
        pos.x = Mathf.Lerp(pos.x, cameraValue.backgroundTarget.x * ratio + offset, CameraValue.SmoothSpeed);
        g.transform.position = pos;
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
