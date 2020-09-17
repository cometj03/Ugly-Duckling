using UnityEngine;

public class WolfSign : MonoBehaviour
{
    public GameObject wolfPrefab;

    private GameObject wolfInstance;
    private Transform birdTarget;
    private bool isInstance;
    
    void Start()
    {
        birdTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (birdTarget.position.x - transform.position.x > 4 && !isInstance)
        {
            Vector3 wolfPos = transform.position;
            wolfPos.x -= 6;
            wolfInstance = Instantiate(wolfPrefab, wolfPos, Quaternion.identity);
            isInstance = true;
        }
    }
}
