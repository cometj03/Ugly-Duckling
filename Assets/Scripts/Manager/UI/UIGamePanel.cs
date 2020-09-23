using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGamePanel : MonoBehaviour
{
    public GameObject PausePanel, ClearPanel, OverPanel;

    private bool isPause;

    private CanvasGroup gamePanelCanvasGroup;
    
    private void Start()
    {
        PausePanel.SetActive(false);
        ClearPanel.SetActive(false);
        OverPanel.SetActive(false);

        gamePanelCanvasGroup = PausePanel.transform.parent.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerData.Instance.currentState == GameState.CONTINUE)
            TogglePause();
        
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKey(KeyCode.Escape) && PlayerData.Instance.currentState == GameState.CONTINUE)
                TogglePause();
    }

    public void TogglePause()
    {
        if (isPause)
        {
            PlayerData.Instance.currentState = GameState.CONTINUE;
            isPause = false;
        }
        else
        {
            PlayerData.Instance.currentState = GameState.PAUSE;
            isPause = true;
        }
        PausePanel.SetActive(isPause);
    }

    public void PlayAgainBtn()
    {
        GameManager.instance.CameraReset();
        FindObjectOfType<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenClearPanel() => ClearPanel.SetActive(true);

    public void OpenOverPanel()
    {
        OverPanel.SetActive(true);
        StartCoroutine(PanelFadeIn());
    }

    public void ExitBtn() => FindObjectOfType<LevelLoader>().LoadNextLevel("StandbyScene");

    public void NextStageBtn()
    {
        int level = PlayerData.Instance.currentLevel;
        
        PlayerData.Instance.currentLevel++; // 레벨 1 더함
        
        switch (level)
        {
            case 10:
                FindObjectOfType<LevelLoader>().LoadNextLevel("2_Autumn");
                break;
            case 20:
                FindObjectOfType<LevelLoader>().LoadNextLevel("3_Winter");
                break;
            case 30:
                ExitBtn();  // 준비화면으로 나감
                break;
            default:
                FindObjectOfType<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }
    
    IEnumerator PanelFadeIn()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += 0.03f;
            gamePanelCanvasGroup.alpha = alpha;
            yield return null;
        }
    }
}
