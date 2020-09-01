using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HorizontalButton : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite defaultSprite, rightSprite, leftSprite;
    
    private Vector3 currentMousePos;
    private RectTransform btnPos;
    private Image btnImage;
    private float posX;
    private int dir;    // -1: left, 0: default, 1: right 

    private void Start()
    {
        btnPos = gameObject.GetComponent<RectTransform>();
        btnImage = gameObject.GetComponent<Image>();
        btnImage.sprite = defaultSprite;
        
        posX = btnPos.anchoredPosition.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentMousePos = Input.mousePosition;
        if (dir != 1 && currentMousePos.x > posX)
        {
            dir = 1;
            btnImage.sprite = rightSprite;
        }
        else if (dir != -1 && currentMousePos.x <= posX)
        {
            dir = -1;
            btnImage.sprite = leftSprite;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        currentMousePos = Input.mousePosition;
        btnImage.sprite = currentMousePos.x > posX ? rightSprite : leftSprite;
        dir = currentMousePos.x > posX ? 1 : -1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dir = 0;
        btnImage.sprite = defaultSprite;
    }

    public int getDir()
    {
        return dir;
    }
}
