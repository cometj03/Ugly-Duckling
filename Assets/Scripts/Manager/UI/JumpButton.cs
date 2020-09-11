using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private BirdController _birdController;
    
    private void Awake()
    {
        GameObject bird = GameObject.Find("bird");
        if (bird != null)
            _birdController = bird.GetComponent<BirdController>();
    }

    // 점프 버튼 누름
    public void JumpBtn() => _birdController.BirdJump();
}
