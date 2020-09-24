using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private void Start()
    {
        if (PlayerData.Instance.currentLevel != 1) return;

        TutorialLoop();
    }

    private void TutorialLoop()
    {
        while (true)
        {
            break;
        }
    }
}
