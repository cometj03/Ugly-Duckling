﻿using System.Collections;
using UnityEngine;

public class BlackCloud : MonoBehaviour
{
    private ParticleSystem rain;
    
    enum CloudState
    {
        IDLE, RAINNING
    }

    private GameObject scanObject;
    private Animator anim;
    private Transform targetBird;
    private CloudState cloudState;

    private static readonly int State = Animator.StringToHash("State");
    private float len;

    void Start()
    {
        rain = transform.GetChild(0).GetComponent<ParticleSystem>();
        
        anim = GetComponent<Animator>();
        targetBird = GameObject.FindGameObjectWithTag("Player").transform;

        anim.SetFloat(State, 0);
        cloudState = CloudState.IDLE;
    }

    void LateUpdate()
    {
        if (Mathf.Abs(gameObject.transform.position.x - targetBird.position.x) < 1.2f)
        {
            StartCoroutine(TurningToRain(0.4f));
            anim.SetFloat(State, 1);
            if(!rain.isPlaying)
                rain.Play();
        }
        else
        {
            len = 0f;
            cloudState = CloudState.IDLE;
            anim.SetFloat(State, 0);
            if(rain.isPlaying)
                rain.Stop();
        }
    }

    private void FixedUpdate()
    {
        bool isOver = false;
        if (cloudState == CloudState.RAINNING)
        {
            // 밑에 체크
            Vector3 origin = transform.position;
            origin.y -= 0.2f;
            Debug.DrawRay(origin, Vector2.down * len, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, len);
            if (hit.collider != null)
            {
                scanObject = hit.collider.gameObject;
                isOver = !scanObject.CompareTag("Tile");
            }
            else
            {
                len += 0.2f;
                scanObject = null;
            }

            if (isOver && PlayerData.Instance.currentState != GameState.OVER)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    private IEnumerator TurningToRain(float time)
    { 
        yield return new WaitForSeconds(time);
        cloudState = CloudState.RAINNING;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BirdController>().BirdPush(-35, 90);
            GameManager.instance.GameOver();
        }
    }
}
