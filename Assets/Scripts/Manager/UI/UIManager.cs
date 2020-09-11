using UnityEngine;

public class UIManager : MonoBehaviour
{
    private CameraZoom _cameraZoom;

    private void Awake()
    {
        GameObject standbyCamera = GameObject.Find("Main Camera");
        if (standbyCamera != null)
            _cameraZoom = standbyCamera.GetComponent<CameraZoom>();
    }
    
    public void BtnPlay(string world)
    {
        gameObject.GetComponent<StandbyScene>().StartGame(world);
    }

    public void BtnCustomize()
    {
        gameObject.GetComponent<StandbyScene>().isCamMoving = false;
        StartCoroutine(_cameraZoom.CustomizeZoomIn());    // 줌인
    }

    public void BtnCustomizeExit()
    {
        StartCoroutine(_cameraZoom.CustomizeZoomOut());    // 줌아웃
    }
}
