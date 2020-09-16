using UnityEngine;

public class World02_Autumn : MonoBehaviour
{
    public CameraValue cameraValue;
    
    [SerializeField] GameObject background = default;
    [SerializeField] GameObject sun = default;
    [SerializeField] GameObject floor = default;

    private GameObject maincamera;
    private float floorWidth, cloudWidth;
    private float sunOffset;
    
    
    void Start()
    {
        // 바닥 가로 길이
        floorWidth = floor.GetComponent<SpriteRenderer>().size.x * floor.transform.localScale.x;
        
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        sunOffset = sun.transform.position.x - cameraValue.cameraTarget.x;
    }

    void FixedUpdate()
    {
        // floor 반복
        float floorDiff = maincamera.transform.position.x - floor.transform.position.x;
        if (floorDiff >= floorWidth / 4)
            floor.transform.position += Vector3.right * floorWidth / 2;
        else if (floorDiff <= -floorWidth / 4)
            floor.transform.position -= Vector3.right * floorWidth / 2;
        
        // 배경 움직임
        Vector3 bgPos = background.transform.position;
        bgPos.x = maincamera.transform.position.x;
        background.transform.position = bgPos;
        MoveBgObject(sun, sunOffset, 0.95f);
    }
    
    private void MoveBgObject(GameObject gameObject, float offset, float ratio)
    {
        Vector3 pos = gameObject.transform.position;
        pos.x = Mathf.Lerp(pos.x, cameraValue.cameraTarget.x * ratio + offset, CameraValue.SmoothSpeed);
        gameObject.transform.position = pos;
    }
}
