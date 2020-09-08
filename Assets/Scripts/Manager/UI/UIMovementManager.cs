using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMovementManager : MonoBehaviour
{ 
    public GameObject buttons;
    public GameObject worldSelect;
    
    private RectTransform _buttonsRect, _worldRect;
    private bool isButtonsCome;

    private void Start()
    {
        _buttonsRect = buttons.GetComponent<RectTransform>();
        _worldRect = worldSelect.GetComponent<RectTransform>();
        isButtonsCome = false;

        StartCoroutine(ButtonsIn());
        StartCoroutine(WorldSelectIn());
    }

    IEnumerator WorldSelectIn()
    {
        Vector3 worldPos = _worldRect.anchoredPosition = new Vector3(625, _worldRect.anchoredPosition.y);

        while (_buttonsRect.anchoredPosition.x >= -624.5f)
        {
            worldPos.x = Mathf.Lerp(worldPos.x, -625f, 0.01f);
            _worldRect.anchoredPosition = worldPos;

            yield return null;
        }
    }
    
    IEnumerator ButtonsIn()
    {
        // 버튼들 화면 밖에서 안으로 들어오는 함수
        isButtonsCome = true;
        Vector3 buttonPos = _buttonsRect.anchoredPosition = new Vector3(_buttonsRect.anchoredPosition.x, 100);

        while (_buttonsRect.anchoredPosition.y >= -130 && isButtonsCome)
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
