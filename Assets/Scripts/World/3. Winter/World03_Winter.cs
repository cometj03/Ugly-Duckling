using UnityEngine;

public class World03_Winter : MonoBehaviour
{
    public CameraValue cameraValue;
    private GameObject maincamera;
    
    [SerializeField] GameObject background = default;
    [SerializeField] GameObject moon = default;
    [SerializeField] GameObject mountain = default;
    [SerializeField] GameObject snowyfloor = default;

    private float floorWidth;
    private float bgOffsetX, moonOffsetX, mtOffsetX;
    
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        // 바닥의 가로 길이
        floorWidth = snowyfloor.GetComponent<SpriteRenderer>().size.x * snowyfloor.transform.localScale.x;

        float cameraX = maincamera.transform.position.x;
        bgOffsetX = background.transform.position.x - cameraX;
        moonOffsetX = moon.transform.position.x - cameraX;
        mtOffsetX = mountain.transform.position.x - cameraX;
    }

    void FixedUpdate()
    {
        // floor 반복
        float diff = maincamera.transform.position.x - snowyfloor.transform.position.x;
        if (diff >= floorWidth / 6)
            snowyfloor.transform.position += Vector3.right * floorWidth / 3;
        else if (diff <= -floorWidth / 6)
            snowyfloor.transform.position -= Vector3.right * floorWidth / 3;
        
        // 배경 오브젝트 이동
        MoveBgObject(background, bgOffsetX, 0.95f);
        MoveBgObject(moon, moonOffsetX, 0.9f);
        MoveBgObject(mountain, mtOffsetX, 0.5f);
    }
    
    private void MoveBgObject(GameObject gameObject, float offset, float ratio)
    {
        Vector3 pos = gameObject.transform.position;
        pos.x = Mathf.Lerp(pos.x, cameraValue.cameraTarget.x * ratio + offset, CameraValue.SmoothSpeed);
        gameObject.transform.position = pos;
    }
}
