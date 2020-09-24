using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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

    private void Start()
    {
        _cameraZoom = FindObjectOfType<CameraZoom>();
        
        // 초기 세팅
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        customizeCanvas.SetActive(false);

        StagesSelected(-1);    // All stages invisable
        
        // 보유금액의 변경을 감지하고 변경되면 moneyText에 갱신하기
        PlayerData.Instance.MoneyProperty.Subscribe(value =>
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
                moneyText.text = value.ToString();
        });
    }
    
    public void BtnPlay()
    {
        SoundManager.instance.PlaySFX(eSFX.BtnClick1);

        // 클릭한 스테이지 버튼 불러옴
        GameObject clickedBtn = EventSystem.current.currentSelectedGameObject;
        
        // 레벨 저장
        string levelString = clickedBtn.transform.GetChild(0).GetComponent<Text>().text;
        PlayerData.Instance.currentLevel = System.Convert.ToInt32(levelString);
        // 계절 이름 가져옴
        string worldName = clickedBtn.transform.parent.name;
        
        FindObjectOfType<StandbyScene>().StartGame(worldName);
    }

    public void BtnSettings()
    {
        SoundManager.instance.PlaySFX(eSFX.BtnClick1);
        
        musicSlider.value = PlayerData.Instance.musicVolume;
        sfxSlider.value = PlayerData.Instance.sfxVolume;
        
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        StagesSelected(-1);    // All stages invisable
    }

    public void BtnSettingsExit()
    {
        SoundManager.instance.PlaySFX(eSFX.BtnClick1);
        
        PlayerData.Instance.Save(eSaveType.eSetting);    // 세팅 정보 저장
        
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        if (isShowStages)
            StagesSelected(currentWorld);    // 되돌리기
    }

    public void BtnCustomize()
    {
        SoundManager.instance.PlaySFX(eSFX.Crunchy);
        
        moneyText.text = PlayerData.Instance.MoneyProperty.Value.ToString();    // 보유 금액 표시
        gameObject.GetComponent<StandbyScene>().isCamMoving = false;
        StartCoroutine(_cameraZoom.CustomizeZoomIn());    // 줌인
    }

    public void BtnCustomizeExit()
    {
        SoundManager.instance.PlaySFX(eSFX.Crunchy);
        
        PlayerData.Instance.Save(eSaveType.eUser);    // 유저 정보 저장
        PlayerData.Instance.Save(eSaveType.eSkinList);
        StartCoroutine(_cameraZoom.CustomizeZoomOut());    // 줌아웃
    }

    public void BtnStagesExit()
    {
        SoundManager.instance.PlaySFX(eSFX.BtnClick1);
        isShowStages = false;
    }
    
    public void WorldSelected(int order)
    {
        SoundManager.instance.PlaySFX(eSFX.BtnClick1);
        isShowStages = true;
        currentWorld = order;
        StagesSelected(order);

        for (int i = 0; i < Environment.childCount; i++)
        {
            if (currentWorld == i)
            {
                Environment.GetChild(i).gameObject.SetActive(true);
                
                // Debug.Log(GetButtonPosX());
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
            {
                stages.GetChild(i).gameObject.SetActive(true);
                StartCoroutine(StageFadeIn());
            }
            else
                stages.GetChild(i).gameObject.SetActive(false);
        }
    }

    IEnumerator StageFadeIn()
    {
        float alpha = 0f;

        CanvasGroup stageCanvasGroup = stages.GetChild(currentWorld).GetComponent<CanvasGroup>();
        while (alpha < 1)
        {
            stageCanvasGroup.alpha = alpha;
            alpha += 0.02f;
            yield return null;
        }

        stageCanvasGroup.alpha = 1;
    }

    private float GetButtonPosX()
    {
        float contentPosX = worldSelectContent.anchoredPosition.x;    // Rect Left value
        float btnPosX = (currentWorld * 900 + contentPosX * 1.2f) / 550;
        return btnPosX;
    }
}
