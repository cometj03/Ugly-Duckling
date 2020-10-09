using System.Collections;
using System.Runtime.CompilerServices;
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
                ChangeText("오리가 앞으로 나아갈 수 있게 도와주세요.");
            else if (birdPosX < 1.5f)
                Close();
            else if (birdPosX < 4)
                ChangeText("스와이프를 통해 앞에 있는 퍼즐을 움직여주세요.");
            else if (birdPosX < 5.5f)
                Close();
            else if (birdPosX < 8f)
                ChangeText("잘했어요!");
            else if (birdPosX < 11.5f)
                Close();
            else if (birdPosX < 13f)
                ChangeText("이번엔 점프 버튼을 눌러 블럭 위로 올라가세요.");
            else if (birdPosX < 14f)
                Close();
            else if (birdPosX < 14.8f)
                ChangeText("조심! 앞에 악어가 있어요!");
            else if (birdPosX < 15f)
                Close();
            else if (birdPosX < 17f)
                ChangeText("가장자리에서 언덕으로 점프해보세요.");
            else if (birdPosX < 18.5f)
                Close();
            else if (birdPosX < 20)
            {
                if (birdTransform.position.y > 0)   // 언덕 위로 올라감
                    ChangeText("잘했어요!");
                else
                {
                    ChangeText("다시 시도해보세요.");   // 떨어짐
                    StartCoroutine(GameAgain());
                }
            }
            else if (birdPosX < 21.5f)
                Close();
            else if (birdPosX < 23f)
                ChangeText("블럭으로 구름 밑을 가려서 비를 피할 수 있게 도와주세요.");
            else if (birdPosX < 24.8f)
                Close();
            else if (birdPosX < 26f)
                ChangeText("잘했어요!");
            else if (true)
                Close();
            
                
            yield return null;
        }
    }

    void ChangeText(string dialog)
    {
        if (!isCanvasOpen)
            StartCoroutine(ShowCanvas(dialog)); 
    }

    void Close()
    {
        if (isCanvasOpen)
            StartCoroutine(CloseCanvas());
    }

    IEnumerator GameAgain()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ShowCanvas(string dialog)
    {
        isCanvasOpen = true;
        while (cg.alpha > 0)
        {
            cg.alpha -= 0.02f;
            yield return null;
        }

        tutorialCanvas.GetChild(0).GetChild(0).GetComponent<Text>().text = dialog;
        
        while (cg.alpha < 1 && isCanvasOpen)
        {
            cg.alpha += 0.02f;
            yield return null;
        }
        cg.alpha = 1;
    }

    IEnumerator CloseCanvas()
    {
        isCanvasOpen = false;
        while (cg.alpha < 1)
        {
            cg.alpha += 0.02f;
            yield return null;
        }

        while (cg.alpha > 0 && !isCanvasOpen)
        {
            cg.alpha -= 0.015f;
            yield return null;
        }
        cg.alpha = 0;
    }
}
