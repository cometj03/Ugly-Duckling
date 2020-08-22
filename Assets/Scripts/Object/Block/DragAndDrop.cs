using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera _camera;

    private Vector3 posOffset;
    private bool isDragging;

    private void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void OnMouseDown()
    {
        posOffset = _camera.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        posOffset.z = 0;
    }

    private void OnMouseDrag()
    {
        Vector3 point = _camera.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        gameObject.transform.position = point - posOffset;
    }
}
