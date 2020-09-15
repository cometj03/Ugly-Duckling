using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    
    private static readonly int Start = Animator.StringToHash("Start");
    private float transitionTime = 1f;

    public void LoadNextLevel(int sceneIndex) => StartCoroutine(LoadLevel(sceneIndex));
    
    public void LoadNextLevel(string sceneName) => StartCoroutine(LoadLevel(sceneName));

    
    private IEnumerator LoadLevel(string sceneName)
    {
        Transition.SetTrigger(Start);
        
        yield return new WaitForSeconds(transitionTime);

        eMusic musicType;
        switch (sceneName)
        {
            case "1_Summer":
                musicType = eMusic.SUMMER;
                break;
            case "2_Autumn":
                musicType = eMusic.AUTUMN;
                break;
            case "3_Winter":
                musicType = eMusic.WINTER;
                break;
            default:
                musicType = eMusic.MAIN;
                break;
        }

        SoundManager.instance.ChangeBGM(musicType);
        SceneManager.LoadScene(sceneName);
    }
    
    private IEnumerator LoadLevel(int sceneIndex)
    {
        Transition.SetTrigger(Start);
        
        yield return new WaitForSeconds(transitionTime);

        eMusic musicType;
        switch (sceneIndex)
        {
            case 2:
                musicType = eMusic.SUMMER;
                break;
            case 3:
                musicType = eMusic.AUTUMN;
                break;
            case 4:
                musicType = eMusic.WINTER;
                break;
            default:
                musicType = eMusic.MAIN;
                break;
        }

        SoundManager.instance.ChangeBGM(musicType);
        SceneManager.LoadScene(sceneIndex);
    }
}
