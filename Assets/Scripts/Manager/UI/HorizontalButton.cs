using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HorizontalButton : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite defaultSprite, rightSprite, leftSprite;
    
    private RectTransform btnPos;
    private Image btnImage;
    private float currentTouchPosX;
    private float btnPosX;
    private int dir;    // -1: left, 0: default, 1: right 

    private void Start()
    {
        btnPos = gameObject.GetComponent<RectTransform>();
        btnImage = gameObject.GetComponent<Image>();
        btnImage.sprite = defaultSprite;
        
        btnPosX = btnPos.anchoredPosition.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        /*currentMousePos = Input.mousePosition;
        if (Input.touches.Length > 1)
        {
            // 터치 두 개 이상
            foreach (Touch touch in Input.touches)
            {
                if (currentMousePos.x > touch.position.x)
                    currentMousePos = touch.position;
            }
        }*/
        currentTouchPosX = eventData.position.x;
        if (dir != 1 && currentTouchPosX > btnPosX)
        {
            dir = 1;
            btnImage.sprite = rightSprite;
        }
        else if (dir != -1 && currentTouchPosX <= btnPosX)
        {
            dir = -1;
            btnImage.sprite = leftSprite;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dir = 0;
        currentTouchPosX = 0;
        btnImage.sprite = defaultSprite;
    }

    public int GETDir()
    {
        return dir;
    }
}
