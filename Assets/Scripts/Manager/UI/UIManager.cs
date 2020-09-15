using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public Text moneyText;

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
    }
    
    public void BtnPlay(string world)
    {
        gameObject.GetComponent<StandbyScene>().StartGame(world);
    }

    public void BtnSettings()
    {
        musicSlider.value = PlayerData.Instance.musicVolume;
        sfxSlider.value = PlayerData.Instance.sfxVolume;
        
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        StagesSelected(0);    // All stages active false
    }

    public void BtnSettingsExit()
    {
        PlayerData.Instance.Save(eSaveType.eSetting);    // 세팅 정보 저장
        
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        if (isShowStages)
            StagesSelected(currentWorld);    // 되돌리기
    }

    public void BtnCustomize()
    {
        moneyText.text = PlayerData.Instance.money.ToString();    // 보유 금액 표시
        gameObject.GetComponent<StandbyScene>().isCamMoving = false;
        StartCoroutine(_cameraZoom.CustomizeZoomIn());    // 줌인
    }

    public void BtnCustomizeExit()
    {
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
