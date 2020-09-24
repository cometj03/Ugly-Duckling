using UnityEngine;

public class StageLoadManager : MonoBehaviour
{
    public GameObject[] Stages;

    private void LoadStage()
    {
        int stageIndex = PlayerData.Instance.currentLevel;

        if (stageIndex % 10 != 0)
            stageIndex %= 10;
        else
            stageIndex = 10;

        if (stageIndex >= 6 && stageIndex < 10) // 스테이지 6~10번 선택했을 때
            stageIndex -= 5;

        if (stageIndex > Stages.Length)
            Debug.LogError("스테이지 인덱스 " + stageIndex + "번이 존재하지 않습니다.");

        Debug.Log("현재 스테이지 인덱스 : " + (stageIndex - 1));
        // 스테이지 생성
        Instantiate(Stages[stageIndex - 1]);
    }

    private void Awake()
    {
        LoadStage();
    }
}
