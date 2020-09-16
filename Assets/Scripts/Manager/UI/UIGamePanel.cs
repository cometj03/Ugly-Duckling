using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGamePanel : MonoBehaviour
{
    public GameObject PausePanel, ClearPanel, OverPanel;

    private bool isPause, isClear, isOver;
    
    private void Awake()
    {
        PausePanel.SetActive(false);
        ClearPanel.SetActive(false);
        OverPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    public void OpenOverPanel() => OverPanel.SetActive(true);

    public void ExitBtn() => FindObjectOfType<LevelLoader>().LoadNextLevel("StandbyScene");
    public void NextStageBtn() => FindObjectOfType<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
}
