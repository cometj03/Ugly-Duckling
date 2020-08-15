using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    private CameraZoom _cameraZoom;
    private RunningScene _runningScene;

    private void Start()
    {
        if (GameObject.Find("Main Camera").GetComponent<CameraZoom>() != null)
            _cameraZoom = GameObject.Find("Main Camera").GetComponent<CameraZoom>();
        if (gameObject.GetComponent<RunningScene>() != null)
            _runningScene = gameObject.GetComponent<RunningScene>();
    }

    //-------------StandbyScene-------------
    public void OnPlayBtnClicked()   // 플레이 버튼 누름
    {
        gameObject.GetComponent<StandbyScene>().StartGame("offline");
    }

    public void OnCustomizeBtnClicked()
    {
        gameObject.GetComponent<StandbyScene>().isCamMoving = false;
        // 줌인
        StartCoroutine(_cameraZoom.CustomizeZoomIn());
    }

    public void OnZoomOutBtnClicked()
    {
        // 줌아웃
        StartCoroutine(_cameraZoom.CustomizeZoomOut());
    }

    //-------------RunningScene-------------
    public void OnJumpBtnClicked()    // 점프 버튼 누름
    {
        if (_runningScene.can_jump)
        {
            _runningScene.bird.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 350);
            _runningScene.can_jump = false;
        }
    }
}
