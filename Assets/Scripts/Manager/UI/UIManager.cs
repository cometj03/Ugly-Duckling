using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    
    public GameObject[] worlds;
    
    private CameraZoom _cameraZoom;
    private BirdCustomAnimation _birdAnim;

    private void Awake()
    {
        _cameraZoom = FindObjectOfType<CameraZoom>();
        _birdAnim = FindObjectOfType<BirdCustomAnimation>();

        musicSlider.value = PlayerData.Instance.musicVolume;
        sfxSlider.value = PlayerData.Instance.sfxVolume;
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
                _birdAnim.ChangeSkin("Bird");
                break;
            case 1:
                _birdAnim.ChangeSkin("SchoolUniform");
                break;
            case 2:
                _birdAnim.ChangeSkin("Bee");
                break;
        }
    }
}
