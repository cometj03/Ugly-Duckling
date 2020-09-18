using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 대기 화면 UI 관리
    /// </summary>
    public GameObject mainCanvas, settingsCanvas, customizeCanvas;

    [Header("Settings Canvas")]
    public Slider musicSlider, sfxSlider;
    public Text moneyText;
    
    [Header("World Select Button")]
    public RectTransform worldSelectContent;
    
    [Header("Worlds")]
    public Transform Environment;
    public Transform stages;

    
    private CameraZoom _cameraZoom;
    private int currentWorld;
    private bool isShowStages;

    private void Awake()
    {
        _cameraZoom = FindObjectOfType<CameraZoom>();
    }
    
    public void BtnPlay(string world)
    {
        SoundManager.instance.PlayBtnSFX(eSFX.BtnClick1);
        
        gameObject.GetComponent<StandbyScene>().StartGame(world);
    }

    public void BtnSettings()
    {
        SoundManager.instance.PlayBtnSFX(eSFX.BtnClick1);
        
        musicSlider.value = PlayerData.Instance.musicVolume;
        sfxSlider.value = PlayerData.Instance.sfxVolume;
        
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        StagesSelected(-1);    // All stages active false
    }

    public void BtnSettingsExit()
    {
        SoundManager.instance.PlayBtnSFX(eSFX.BtnClick1);
        
        PlayerData.Instance.Save(eSaveType.eSetting);    // 세팅 정보 저장
        
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        if (isShowStages)
            StagesSelected(currentWorld);    // 되돌리기
    }

    public void BtnCustomize()
    {
        SoundManager.instance.PlayBtnSFX(eSFX.Crunchy);
        
        moneyText.text = PlayerData.Instance.money.ToString();    // 보유 금액 표시
        gameObject.GetComponent<StandbyScene>().isCamMoving = false;
        StartCoroutine(_cameraZoom.CustomizeZoomIn());    // 줌인
    }

    public void BtnCustomizeExit()
    {
        SoundManager.instance.PlayBtnSFX(eSFX.Crunchy);
        
        PlayerData.Instance.Save(eSaveType.eUser);    // 유저 정보 저장
        StartCoroutine(_cameraZoom.CustomizeZoomOut());    // 줌아웃
    }

    public void BtnStagesExit()
    {
        SoundManager.instance.PlayBtnSFX(eSFX.BtnClick1);
        isShowStages = false;
    }
    
    public void WorldSelected(int order)
    {
        SoundManager.instance.PlayBtnSFX(eSFX.BtnClick1);
        StagesSelected(order);
        isShowStages = true;
        currentWorld = order;

        for (int i = 0; i < Environment.childCount; i++)
        {
            if (currentWorld == i)
            {
                Environment.GetChild(i).gameObject.SetActive(true);
                
                Debug.Log(GetButtonPosX());
                Transform hole = Environment.GetChild(i).GetChild(0).GetChild(0);
                hole.position = Vector3.right * GetButtonPosX();
                hole.localScale = Vector3.zero;
                hole.GetComponent<Animator>().SetBool("Play", true);
                hole.GetComponent<Animator>().SetBool("Play", false);
            }
            else
            {
                Environment.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void StagesSelected(int order)
    {
        for (int i = 0; i < stages.childCount; i++)
        {
            if (order == i)
                stages.GetChild(i).gameObject.SetActive(true);
            else
                stages.GetChild(i).gameObject.SetActive(false);
        }
    }

    private float GetButtonPosX()
    {
        float contentPosX = worldSelectContent.anchoredPosition.x;    // Rect Left value
        float btnPosX = (currentWorld * 900 + contentPosX * 1.2f) / 550;
        return btnPosX;
    }
}
