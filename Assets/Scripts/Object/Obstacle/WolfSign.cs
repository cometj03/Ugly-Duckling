using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;

public class WolfSign : MonoBehaviour
{
    public GameObject wolfPrefab;
    public Sprite[] waringAnimation;

    private Transform birdTarget;
    SpriteRenderer waringMark;

    bool isInstance, isAnim;

    
    void Start()
    {
        birdTarget = GameObject.FindGameObjectWithTag("Player").transform;
        waringMark = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (birdTarget.position.x > transform.position.x && !isAnim)   // 오리가 표지판을 지날 때
        {
            isAnim = true;
            StartCoroutine(DoSignAnim());
        } 
        else if (birdTarget.position.x < transform.position.x && isAnim)    // 오리가 다시 표지판 밖으로 나갈 때
        {
            Debug.Log("밖으로 나감");
            isAnim = false;
            StartCoroutine(DoSignCloseAnim());
        }

        if (birdTarget.position.x - transform.position.x > 4 && !isInstance)    // 늑대 생성될 때
        {
            Vector3 wolfPos = transform.position;
            wolfPos.x -= 6;
            Instantiate(wolfPrefab, wolfPos, Quaternion.identity);
            isInstance = true;

            waringMark.sprite = waringAnimation[waringAnimation.Length - 1];
        }
    }

    IEnumerator DoSignAnim()
    {
        for (int i = 0; i < waringAnimation.Length - 1; i++)
        {
            waringMark.sprite = waringAnimation[i];
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator DoSignCloseAnim()
    {
        for (int i = waringAnimation.Length - 2; i >= 0; i--)
        {
            waringMark.sprite = waringAnimation[i];
            yield return new WaitForSeconds(0.2f);
        }
        waringMark.sprite = null;
    }
}
