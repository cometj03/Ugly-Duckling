using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
	/// <summary>
	/// 메인화면에서 필요한 모든 조작을 담당함
	/// </summary>

	public Text text;	// touch to start Text
	public GameObject player;	// 오리 객체 
	public GameObject canvas;	// FadeIn하는 이미지

	private bool fade = true;   // touch to start 가 흐려지게 하건지 뚜렷해지게 할건지 여부
	private static readonly int IsWalk = Animator.StringToHash("is_walk");	// 애니메이션 is_walk 트리거 저장
	private IEnumerator _touchToStart;

	private void Awake()
    {
		// Screen.SetResolution(Screen.height * 16 / 9, Screen.height, true);
		// Debug.Log(Screen.width + ", " + Screen.height);
    }

    private void Start()
    {
	    _touchToStart = TouchToStart();
    }

    private void Update()
	{
		// touch to start가 깜박거리는 효과를 주는 코드
		if (fade)
		{
			var color = text.color;
			color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime * 0.8f);
			text.color = color;
			if (text.color.a <= 0)
				fade = false;
		}
		else
		{
			var color = text.color;
			color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime * 0.8f);
			text.color = color;
			if (text.color.a >= 1)
				fade = true;
		}

		// 프레이어가 화면 터치시 오리가 화면 밖으로 나가고 다음 씬으로 넘어감
		if (Input.touchCount > 0 || Input.anyKeyDown) 
		{
			StartCoroutine(_touchToStart);
		}
	}

	IEnumerator TouchToStart()
	{
		float birdSpeed = 1.5f;
		player.GetComponent<SpriteRenderer>().flipX = true;
		player.GetComponent<Animator>().SetBool(IsWalk, true);
		while (player.transform.position.x < 6)
		{
			player.transform.Translate(new Vector3(birdSpeed, 0, 0) * Time.deltaTime);
			
			// 가는 도중 한 번 더 화면 터치하면 속도 증가
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
					birdSpeed = 2.5f;
			} else if (Input.anyKeyDown)
				birdSpeed = 2.5f;

			yield return null;
			// yield return new WaitForEndOfFrame();
		}
		// 다음 씬으로 넘어감
		canvas.GetComponent<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
