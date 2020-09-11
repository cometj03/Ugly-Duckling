using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunningScene : MonoBehaviour
{
    public LevelLoader levelLoader;
    
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                levelLoader.LoadNextLevel("StandbyScene");
            }
        }
    }
}
