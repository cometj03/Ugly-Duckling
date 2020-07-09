using System.Collections;
using System.Collections.Generic;
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
	public Image panel;	// 화면을 덮어주는 패널

	private bool fade = true;   // touch to start 가 흐려지게 하건지 뚜렷해지게 할건지 여부

	private void Awake()
    {
		Screen.SetResolution(Screen.height * 16 / 9, Screen.height, true);
		// Debug.Log(Screen.width + ", " + Screen.height);
    }

    private void Start()
    {
		panel.color = new Color(0, 0, 0, 0);
    }

    private void Update()
	{
		/// touch to start가 깜박거리는 효과를 주는 코드
		if (fade)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime * 0.8f);
			if (text.color.a <= 0)
				fade = false;
		}
		else
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + Time.deltaTime * 0.8f);
			if (text.color.a >= 1)
				fade = true;
		}

		/// 프레이어가 화면 터치시 오리가 화면 밖으로 나가고 다음 씬으로 넘어감
		if (Input.touchCount > 0 || Input.anyKeyDown) 
		{
			StartCoroutine(TouchToStart());
		}
	}

	IEnumerator TouchToStart()
	{
		float birdSpeed = 1.5f;
		player.GetComponent<SpriteRenderer>().flipX = true;
		player.GetComponent<Animator>().SetBool("is_walk", true);
		while (player.transform.position.x < 6)
		{
			player.transform.Translate(new Vector3(birdSpeed, 0, 0) * Time.deltaTime);
			
			/// 가는 도중 한 번 더 화면 터치하면 속도 증가
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
					birdSpeed = 2.5f;
			} else if (Input.anyKeyDown)
				birdSpeed = 2.5f;

			yield return new WaitForEndOfFrame();
		}
		/// FadeIn 후, 다음 씬으로 넘어감
		StartCoroutine(FadeOut());
	}

	IEnumerator FadeOut()
    {
		while (panel.color.a < 0.95f)
		{
			panel.color = new Color(0, 0, 0, panel.color.a + Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		SceneManager.LoadScene("StandbyScene");
    }
}
