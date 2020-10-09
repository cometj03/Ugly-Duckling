using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    private BirdController _birdController;
    
    private void Awake()
    {
        _birdController = FindObjectOfType<BirdController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _birdController.BirdJump();
    }
}
