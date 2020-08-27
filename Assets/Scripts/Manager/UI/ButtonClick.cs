using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject bird;
    public GameObject standbyCamera;
    
    private CameraZoom _cameraZoom;

    private void Start()
    {
        if (standbyCamera != null)
            _cameraZoom = standbyCamera.GetComponent<CameraZoom>();
    }

    //-------------StandbyScene-------------//
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

    //-------------RunningScene-------------//
    public void OnJumpBtnClicked()    // 점프 버튼 누름
    {
        bird.GetComponent<BirdController>().BirdJump();
    }
}
