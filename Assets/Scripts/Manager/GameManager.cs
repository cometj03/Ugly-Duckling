using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        GameContinue, GameClear, GameOver
    }
    public GameState currentState;
    public CameraValue cameraValue;

    private GameObject maincamera;
    private GameObject bird;
    private Rigidbody2D birdRb2D;
    
    void Start()
    {
        maincamera = GameObject.Find("Main Camera");
        if (GameObject.Find("bird") != null)
            bird = GameObject.Find("bird");
        birdRb2D = bird.GetComponent<Rigidbody2D>();
        currentState = GameState.GameContinue;
    }
    
    void Update()
    {
        if (currentState == GameState.GameOver)
        {
            if (maincamera.transform.position.x < 4)
            {
                bird.transform.position = new Vector3(-3, -0.7f, 0);
                currentState = GameState.GameContinue;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        cameraValue.cameraTarget = Vector3.back * 10;
    }
}
