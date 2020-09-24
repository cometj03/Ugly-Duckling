using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Transform tutorialCanvas;

    private Transform birdTransform;
    private CanvasGroup cg;

    bool isCanvasOpen;

    private void Start()
    {
        if (PlayerData.Instance.currentLevel != 1)
        {
            tutorialCanvas.gameObject.SetActive(false);
            return;
        }

        tutorialCanvas.gameObject.SetActive(true);

        birdTransform = FindObjectOfType<BirdController>().transform; 
        cg = tutorialCanvas.GetComponent<CanvasGroup>();
        cg.alpha = 0;
        isCanvasOpen = false;

        StartCoroutine(TutorialLoop());
    }

    private IEnumerator TutorialLoop()
    {
        float birdPosX = 0;
        while (birdPosX < 100)
        {
            birdPosX = birdTransform.position.x;


            if (birdPosX < 0)
                ChangeText("오리가 움직일 수 있게 도와주세요.");
            else if (birdPosX < 1.5f)   // 0 ~ 1.5
                Close();
            else if (birdPosX < 3)      // 1.5 ~ 3
                ChangeText("스와이프를 통해 앞에 있는 퍼즐을 움직여주세요.");
            else if (birdPosX < 6)      // 3 ~ 6
                Close();
            else if (birdPosX < 7.5f)   // 6 ~ 7.5
                ChangeText("잘했어요!");
            else if (birdPosX < 11.5f)     // 7.5 ~ 11.5
                Close();
            else if (birdPosX < 13.5f)     // 11.5 ~ 13.5
                ChangeText("이번엔 점프 버튼을 눌러 블럭 위로 올라가세요.");
            else if (birdPosX < 14.5f)         // 13.5 ~ 14.5
                Close();
            else if (birdPosX < 15.3f) // 14.5 ~ 15.4
                ChangeText("조심! 앞에 악어가 있어요!");
            else if (birdPosX < 15.6f)         // 15.4 ~ 15.8
                Close();
            else if (birdPosX < 17f)         // 15.8 ~ 17
                ChangeText("가장자리에서 점프를 하면 언덕으로 올라갈 수 있어요.");
            else if (birdPosX < 18.5f)  // 17 ~ 18.5
                Close();
            else if (birdPosX < 20) // 18.5 ~ 20
            {
                if (birdTransform.position.y > 0)   // 언덕 위로 올라감
                    ChangeText("잘했어요!");
                else
                {
                    ChangeText("다시 시도해보세요.");   // 떨어짐
                    StartCoroutine(GameAgain());
                }
            }

            yield return null;
        }
    }

    void ChangeText(string dialog)
    {
        if (!isCanvasOpen)
            StartCoroutine(ShowCanvas(dialog)); 
    }

    void Close() => StartCoroutine(CloseCanvas());

    IEnumerator GameAgain()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ShowCanvas(string dialog)
    {
        isCanvasOpen = true;
        tutorialCanvas.GetChild(0).GetChild(0).GetComponent<Text>().text = dialog;

        while (cg.alpha < 1)
        {
            cg.alpha += 0.01f;
            yield return null;
        }
        cg.alpha = 1;
    }

    IEnumerator CloseCanvas()
    {
        isCanvasOpen = false;

        while (cg.alpha > 0)
        {
            cg.alpha -= 0.001f;
            yield return null;
        }
        cg.alpha = 0;
    }
}
