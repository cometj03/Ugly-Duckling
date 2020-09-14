using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;

    public GameObject mainCanvas, settingsCanvas, customizeCanvas;
    
    public GameObject[] worldBackGrounds;

    public GameObject[] stages;

    private CameraZoom _cameraZoom;
    private BirdCustomAnimation _birdAnim;
    private int currentWorld;
    private bool isShowStages;

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

    public void BtnSettings()
    {
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        StagesSelected(0);    // All stages active false
    }

    public void BtnSettingsExit()
    {
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        if (isShowStages)
            StagesSelected(currentWorld);    // 되돌리기
    }

    public void BtnCustomize()
    {
        gameObject.GetComponent<StandbyScene>().isCamMoving = false;
        StartCoroutine(_cameraZoom.CustomizeZoomIn());    // 줌인
    }

    public void BtnCustomizeExit()
    {
        Debug.Log("asdf");
        PlayerData.Instance.Save(eSaveType.eUser);    // 유저 정보 저장
        StartCoroutine(_cameraZoom.CustomizeZoomOut());    // 줌아웃
    }

    public void BtnStagesExit()
    {
        isShowStages = false;
    }
    
    public void WorldSelected(int order)
    {
        isShowStages = true;
        StagesSelected(order);
        currentWorld = order;
        for (int i = 0; i < worldBackGrounds.Length; i++)
        {
            if (currentWorld == i + 1)
                worldBackGrounds[i].SetActive(true);
            else
                worldBackGrounds[i].SetActive(false);
        }
    }

    void StagesSelected(int order)
    {
        for (int i = 0; i < stages.Length; i++)
        {
            if (order == i + 1)
                stages[i].SetActive(true);
            else
                stages[i].SetActive(false);
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
