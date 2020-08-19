using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }
}
