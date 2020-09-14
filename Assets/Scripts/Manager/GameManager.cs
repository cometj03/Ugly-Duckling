using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        CONTINUE, CLEAR, OVER, PAUSE
    }
    public GameState currentState;
    public CameraValue cameraValue;

    private UIGamePanel _uiGamePanel;
    
    void Awake()
    {
        currentState = GameState.CONTINUE;
        _uiGamePanel = FindObjectOfType<UIGamePanel>();
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // TODO: 
        // PlayerData.Instance.Load(eSaveType.eAll);    // 게임 시작시 모든 데이터 불러옴
    }
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GameClear();
    }

    public void GameClear()
    {
        print("Game Clear!");
        currentState = GameState.CLEAR;
        _uiGamePanel.OpenClearPanel();    // 클리어창 띄움
    }
    
    public IEnumerator GameOver()
    {
        print("Game Over");
        currentState = GameState.OVER;
        yield return new WaitForSeconds(1.3f);
        _uiGamePanel.OpenOverPanel();    // 게임 오버창 띄움
    }
    
    public void CameraReset()
    {
        cameraValue.cameraTarget = Vector3.back * 10;
    }
}
