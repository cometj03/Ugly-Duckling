using System;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            GameManager.instance.GameOver();
    }
}
