using System;
using UnityEngine;

public class WinterIdle : MonoBehaviour
{
    [SerializeField] GameObject mountaincloud = default;
    
    private bool isCloudUp;
    private float cloudPosY;

    private void Start()
    {
        cloudPosY = mountaincloud.transform.position.y;
    }

    void Update()
    {
        if (mountaincloud.transform.position.y >= cloudPosY + 0.15f) // down
            isCloudUp = false;
        else if (mountaincloud.transform.position.y <= cloudPosY - 0.15f) // up
            isCloudUp = true;
		
        float cloudDeltaY = isCloudUp ? 0.1f : -0.1f;
        mountaincloud.transform.position += new Vector3(0, cloudDeltaY * Time.deltaTime);
    }
}
