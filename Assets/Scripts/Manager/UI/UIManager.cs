using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] worlds;
    
    private CameraZoom _cameraZoom;
    private BirdCustomAnimation _birdAnim;

    private void Awake()
    {
        GameObject standbyCamera = GameObject.Find("Main Camera");
        if (standbyCamera != null)
            _cameraZoom = standbyCamera.GetComponent<CameraZoom>();
        
        GameObject bird = GameObject.Find("bird");
        if (bird != null)
            _birdAnim = bird.GetComponent<BirdCustomAnimation>();
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

    public void WorldSelected(int order)
    {
        for (int i = 0; i < worlds.Length; i++)
        {
            if (order == i + 1)
                worlds[i].SetActive(true);
            else
                worlds[i].SetActive(false);
        }
    }

    public void SkinSelected(int order)
    {
        switch (order)
        {
            case 0:
                _birdAnim.ChangeSkin("bird");
                break;
            case 1:
                _birdAnim.ChangeSkin("SchoolUniform");
                break;
        }
    }
}
