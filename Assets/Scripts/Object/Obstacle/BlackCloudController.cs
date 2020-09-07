using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCloudController : MonoBehaviour
{
    private Animator anim;
    private Transform targetBird;
    private static readonly int State = Animator.StringToHash("State");

    void Start()
    {
        anim = GetComponent<Animator>();
        if (GameObject.Find("bird"))
            targetBird = GameObject.Find("bird").transform;
        anim.SetFloat(State, 0);
    }

    void Update()
    {
<<<<<<< HEAD
        if (Mathf.Abs(gameObject.transform.position.x - targetBird.position.x) < 1.5f)
=======
        if (Mathf.Abs(gameObject.transform.position.x - targetBird.position.x) < 1.75f)
>>>>>>> master
            anim.SetFloat(State, 1);
        else
            anim.SetFloat(State, 0);
    }
}
