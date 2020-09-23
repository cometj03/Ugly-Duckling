using System;
using System.Collections;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    public Sprite[] crocodileAnim;

    private SpriteRenderer sr;
    private Transform birdTransform;

    private bool isMouthOpen;
    
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        birdTransform = FindObjectOfType<BirdController>().transform;
    }

    private void LateUpdate()
    {
        if (Mathf.Abs(birdTransform.position.x - transform.position.x) < 2.5f && !isMouthOpen)
        {
            isMouthOpen = true;
            StartCoroutine(OpenMouthAnim());
        } else if (Mathf.Abs(birdTransform.position.x - transform.position.x) >= 2.5f && isMouthOpen)
        {
            isMouthOpen = false;
            StartCoroutine(CloseMouthAnim(0.25f));
        } 
    }

    IEnumerator CloseMouthAnim(float dTime)
    {
        for (int i = 0; i < crocodileAnim.Length; i++)
        {
            sr.sprite = crocodileAnim[i];
            yield return new WaitForSeconds(dTime);
        }
    }

    IEnumerator OpenMouthAnim()
    {
        for (int i = crocodileAnim.Length - 1; i >= 0; i--)
        {
            sr.sprite = crocodileAnim[i];
            yield return new WaitForSeconds(0.15f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseMouthAnim(0.02f));
            other.GetComponent<BirdController>().BirdPush(-35, 80);
            GameManager.instance.GameOver();
        }
    }
}
