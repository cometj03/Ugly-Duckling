using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraZoom : MonoBehaviour
{
    private Camera mainCamera;
    
    private float customizeZoom, originZoom;
    private float zoomLerpSpeed = 3.5f;
    private Vector3 customizeCamPos = new Vector3(-0.75f, -1.1f, -10);
    private Vector3 originCamPos = new Vector3(0, 0, -10);

    private bool isCamZoomimg;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        originZoom = 2.7f;
        customizeZoom = 1.6f;
    }

    public IEnumerator CustomizeZoomIn()
    {
        isCamZoomimg = true;
        while (mainCamera.orthographicSize >= customizeZoom + 0.01f && isCamZoomimg)
        {
            mainCamera.orthographicSize =
                Mathf.Lerp(mainCamera.orthographicSize, customizeZoom, Time.deltaTime * zoomLerpSpeed);

            mainCamera.transform.position =
                Vector3.Lerp(mainCamera.transform.position, customizeCamPos, Time.deltaTime * zoomLerpSpeed);
            yield return null;
        }
        
        if (isCamZoomimg)
        {
            mainCamera.orthographicSize = customizeZoom;
            mainCamera.transform.position = customizeCamPos;
        }
    }

    public IEnumerator CustomizeZoomOut()
    {
        isCamZoomimg = false;
        while (mainCamera.orthographicSize <= originZoom - 0.01f && !isCamZoomimg)
        {
            mainCamera.orthographicSize =
                Mathf.Lerp(mainCamera.orthographicSize, originZoom, Time.deltaTime * zoomLerpSpeed);
            
            mainCamera.transform.position =
                Vector3.Lerp(mainCamera.transform.position, originCamPos, Time.deltaTime * zoomLerpSpeed);
            yield return null;
        }

        if (!isCamZoomimg)
        {
            mainCamera.orthographicSize = originZoom;
            mainCamera.transform.position = originCamPos;
        }
    }
}