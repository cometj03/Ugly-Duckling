using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;
    public enum GameState
    {
        CONTINUE, CLEAR, OVER
    }
    public GameState currentState;
    public CameraValue cameraValue;

    private GameObject maincamera;
    private GameObject bird;
    
    void Start()
    {
        if (instance == null)
            instance = this;
        
        maincamera = GameObject.Find("Main Camera");
        if (GameObject.Find("bird") != null)
            bird = GameObject.Find("bird");
        
        currentState = GameState.CONTINUE;
    }
    
    void Update()
    {
        if (currentState == GameState.OVER)
        {
            if (maincamera.transform.position.x < 4)
            {
                bird.transform.position = new Vector3(-3, -0.7f, 0);
                currentState = GameState.CONTINUE;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        currentState = GameState.OVER;
        cameraValue.cameraTarget = Vector3.back * 10;
    }
}
