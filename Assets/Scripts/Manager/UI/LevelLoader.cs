using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    
    private static readonly int Start = Animator.StringToHash("Start");
    private float transitionTime = 1f;

    public void LoadNextLevel(int levelIndex) => StartCoroutine(LoadLevel(levelIndex));
    public void LoadNextLevel(string sceneName) => StartCoroutine(LoadLevel(sceneName));

    private IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger(Start);
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    private IEnumerator LoadLevel(string sceneName)
    {
        Transition.SetTrigger(Start);
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
