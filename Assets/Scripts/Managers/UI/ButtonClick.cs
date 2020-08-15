using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void Clicked_PlayBtn()   // 플레이 버튼 누름
    {
        gameObject.GetComponent<StandbyScene>().StartGame("offline");
    }
}
