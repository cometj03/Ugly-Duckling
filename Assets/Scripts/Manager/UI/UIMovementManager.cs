using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMovementManager : MonoBehaviour
{ 
    public GameObject buttons;
    //public GameObject world_
    
    private RectTransform _buttonsRect;
    private bool isButtonsCome;

    private void Start()
    {
        _buttonsRect = buttons.GetComponent<RectTransform>();
        isButtonsCome = false;

        StartCoroutine(ButtonsIn());
    }
    
    IEnumerator ButtonsIn()
    {
        // 버튼들 화면 밖에서 안으로 들어오는 함수
        isButtonsCome = true;
        Vector3 buttonPos = _buttonsRect.anchoredPosition = new Vector3(_buttonsRect.anchoredPosition.x, 100);

        while (_buttonsRect.anchoredPosition.y >= -100 && isButtonsCome)
        {
            buttonPos.y = Mathf.Lerp(buttonPos.y, -100.5f, 0.01f);
            _buttonsRect.anchoredPosition = buttonPos;

            yield return null;
        }

        isButtonsCome = false;
    }

    public IEnumerator ButtonsAway()
    {
        // 버튼들 화면 밖으로 나가는 함수
        isButtonsCome = false;
        Vector3 buttonPos = _buttonsRect.anchoredPosition;
        
        while (_buttonsRect.anchoredPosition.y <= 100)
        {
            buttonPos.y = Mathf.Lerp(buttonPos.y, 100.5f, 0.01f);
            _buttonsRect.anchoredPosition = buttonPos;
            
            yield return null;
        }
    }
}
