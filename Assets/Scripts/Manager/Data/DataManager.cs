using UnityEngine;

public class DataManager : MonoBehaviour
{
    private void Awake()
    {
        // TODO: 
        PlayerData.Instance.Load(eSaveType.eAll);    // 게임 시작시 모든 데이터 불러옴
    }
}
