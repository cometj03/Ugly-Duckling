using UnityEngine;

public class WinterIdle : MonoBehaviour
{
    [SerializeField] GameObject mountaincloud = default;
    
    private bool isCloudUp;

    void Update()
    {
        if (mountaincloud.transform.position.y >= -1f)
            isCloudUp = false;
        else if (mountaincloud.transform.position.y <= -1.3f)
            isCloudUp = true;
		
        float cloudDeltaY = isCloudUp ? 0.1f : -0.1f;
        mountaincloud.transform.position += new Vector3(0, cloudDeltaY * Time.deltaTime);
    }
}
