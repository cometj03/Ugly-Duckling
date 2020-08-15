using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMovementManager : MonoBehaviour
{
    
    public GameObject buttons;
    
    private RectTransform _buttonsRect;
    private bool isButtonsCome;

    private void Start()
    {
        _buttonsRect = buttons.GetComponent<RectTransform>();
        isButtonsCome = false;

        // StartCoroutine(ButtonsIn());
    }
    
    IEnumerator ButtonsIn()
    {
        isButtonsCome = true;
        
        // 버튼들 화면 밖에서 안으로 들어오는 함수
        _buttonsRect.anchoredPosition = new Vector3(350f, _buttonsRect.anchoredPosition.y);

        while (_buttonsRect.anchoredPosition.x > -380 && isButtonsCome)
        {
            _buttonsRect.anchoredPosition = 
                new Vector3(_buttonsRect.anchoredPosition.x - 200 * Time.deltaTime, _buttonsRect.anchoredPosition.y);

            yield return null;
        }

        isButtonsCome = false;
    }

    public IEnumerator ButtonsAway()
    {
        // 버튼들 화면 밖으로 나가는 함수
        float awaySpeed = 600;
        isButtonsCome = false;
        while (_buttonsRect.anchoredPosition.x < 400)
        {
            _buttonsRect.anchoredPosition = 
                new Vector3(_buttonsRect.anchoredPosition.x + awaySpeed * Time.deltaTime, _buttonsRect.anchoredPosition.y);

            yield return null;
        }
    }
}
