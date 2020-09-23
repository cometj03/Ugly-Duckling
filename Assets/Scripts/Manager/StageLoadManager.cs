using UnityEngine;

public class StageLoadManager : MonoBehaviour
{
    public GameObject[] Stages;

    private void Awake()
    {
        int stageIndex = PlayerData.Instance.currentLevel - 1;  // stageIndex 0은 튜토리얼

        stageIndex %= 10;

        if (stageIndex > Stages.Length)
            Debug.LogError("스테이지 인덱스 " + stageIndex + "번이 존재하지 않습니다.");

        if (stageIndex > 5 && stageIndex < 10)  // 스테이지 7~10번 선택했을 때
            stageIndex = stageIndex % 5 + 1;

        Debug.Log("현재 스테이지 인덱스 : " + stageIndex);
        // 스테이지 생성
        Instantiate(Stages[stageIndex]);
    }
}
