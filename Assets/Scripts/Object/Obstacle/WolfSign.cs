using System.Collections;
using UnityEngine;

public class WolfSign : MonoBehaviour
{
    public GameObject wolfPrefab;
    public Sprite[] waringAnimation;

    private Transform birdTarget;
    private bool isInstance;

    SpriteRenderer waringMark;
    
    void Start()
    {
        birdTarget = GameObject.FindGameObjectWithTag("Player").transform;
        waringMark = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (birdTarget.position.x - transform.position.x > 4 && !isInstance)
        {
            Vector3 wolfPos = transform.position;
            wolfPos.x -= 6;
            Instantiate(wolfPrefab, wolfPos, Quaternion.identity);
            isInstance = true;

            StartCoroutine(DoSignAnim());
        }
    }

    IEnumerator DoSignAnim()
    {
        for (int i = 0; i < waringAnimation.Length; i++)
        {
            waringMark.sprite = waringAnimation[i];
            yield return new WaitForSeconds(0.2f);
        }
    }
}
