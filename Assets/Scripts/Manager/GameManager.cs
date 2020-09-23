using System.Collections;
using UnityEngine;

public enum GameState
{
    CONTINUE, CLEAR, OVER, PAUSE
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public CameraValue cameraValue;

    private Transform _birdTransform;
    private Transform _camTransform;
    
    private UIGamePanel _uiGamePanel;
    
    void Awake()
    {
        PlayerData.Instance.currentState = GameState.PAUSE;

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
        PlayerData.Instance.Load(eSaveType.eAll);    // 게임 시작시 모든 데이터 불러옴
    }
    
    void LateUpdate()
    {
        if (PlayerData.Instance.currentState == GameState.CONTINUE)
        {
            if (!_birdTransform)
                _birdTransform = FindObjectOfType<BirdController>().transform;
            if (!_camTransform)
                _camTransform = FindObjectOfType<CameraMovement>().transform;
            
            if (_camTransform.position.x - _birdTransform.position.x > 6.5f         // 카메라 밖으로 나감
                || _camTransform.position.y - _birdTransform.position.y > 10)    // 밑으로 떨어짐 
                GameOver();
        }
    }

    public void GameClear()
    {
        print("Game Clear!");
        PlayerData.Instance.currentState = GameState.CLEAR;
        
        if (!_uiGamePanel)
            GetGamePanel();
        
        _uiGamePanel.OpenClearPanel();    // 클리어창 띄움
    }

    public void GameOver()
    {
        if (PlayerData.Instance.currentState == GameState.OVER)
            return;
        StartCoroutine(Over());
    }

    IEnumerator Over()
    {
        print("Game Over");
        PlayerData.Instance.currentState = GameState.OVER;
        yield return new WaitForSeconds(1.3f);
        
        if (!_uiGamePanel)
            GetGamePanel();
        
        _uiGamePanel.OpenOverPanel();    // 게임 오버창 띄움
    }
    
    public void CameraReset()
    {
        cameraValue.backgroundTarget = Vector3.back * 10;
        cameraValue.cameraTarget = Vector3.back * 10;
    }

    private void GetGamePanel() => _uiGamePanel = GameObject.FindGameObjectWithTag("GamePanel").GetComponent<UIGamePanel>();
}
