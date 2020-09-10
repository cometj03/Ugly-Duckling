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
                // StandbyScene의 경로 : 2
                levelLoader.LoadNextLevel(2);
            }
        }
    }
}
