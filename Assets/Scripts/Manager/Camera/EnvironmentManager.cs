using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] GameObject background = default;
    [SerializeField] GameObject moon = default;
    [SerializeField] GameObject mountain = default;
    [SerializeField] GameObject mountaincloud = default;
    [SerializeField] GameObject floor = default;

    public CameraMovement _cameraMovement;
    private Vector3 targetVector;
    private const float smoothCameraSpeed = 0.025f;
    
    //------ World 03 ------//
    private float bgOffsetX, moonOffsetX, mtOffsetX;
    private bool isCloudUp = true;
    
    void Start()
    {
        targetVector = _cameraMovement.cameraTargetVector;

        bgOffsetX = background.transform.position.x - targetVector.x;
        moonOffsetX = moon.transform.position.x - targetVector.x;
        mtOffsetX = mountain.transform.position.x - targetVector.x;
    }

    void FixedUpdate()
    {
        targetVector = _cameraMovement.cameraTargetVector;
        // floor 반복
        if (targetVector.x - 4.8f >= floor.transform.position.x)
            floor.transform.position += Vector3.right * 9.6f;
        
        MoveWorld_Winter();
    }

    private void MoveWorld_Winter()
    {
        //if (maincamera.transform.position.x - 12f >= mountain.transform.position.x)
        //	mountain.transform.position += Vector3.right * 24f;
        
        // 배경 오브젝트 이동
        MoveBgObject(background, bgOffsetX, 0.95f);
        MoveBgObject(moon, moonOffsetX, 0.93f);
        
        if (mountaincloud.transform.position.y > -1f)
            isCloudUp = false;
        else if (mountaincloud.transform.position.y < -1.3f)
            isCloudUp = true;
		
        float cloudDeltaY = isCloudUp ? 0.2f : -0.2f;
        mountain.transform.position += Vector3.right * (0.01f * 0.7f);
        mountaincloud.transform.position += new Vector3(0, cloudDeltaY * (0.01f * 0.7f));
    }
    
    private void MoveBgObject(GameObject gameObject, float offset, float ratio)
    {
        Vector3 pos = gameObject.transform.position;
        pos.x = Mathf.Lerp(pos.x, targetVector.x * ratio + offset, smoothCameraSpeed);
        gameObject.transform.position = pos;
    }
}
