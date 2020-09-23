using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.PlayerMoneyUpdate(2);    // 깃털 2개 획득
            FindObjectOfType<GameManager>().GameClear();
        }
    }
}
