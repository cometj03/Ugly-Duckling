using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private BirdController _birdController;
    
    private void Awake()
    {
        _birdController = FindObjectOfType<BirdController>();
    }

    // 점프 버튼 누름
    public void JumpBtn() => _birdController.BirdJump();
}
