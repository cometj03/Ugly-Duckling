using System;
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
	public LevelLoader levelLoader;	// FadeIn하는 이미지
	public Camera mainCamera;

	private bool fade = true;   // touch to start 가 흐려지게 하건지 뚜렷해지게 할건지 여부
	private static readonly int IsWalk = Animator.StringToHash("is_walk");	// 애니메이션 is_walk 트리거 저장
	private bool isStart = false;

	private void Update()
	{
		// touch to start가 깜박거리는 효과를 주는 코드
		if (fade)
		{
			var color = text.color;
			text.color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime * 0.8f);
			if (text.color.a <= 0)
				fade = false;
		}
		else
		{
			var color = text.color;
			text.color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime * 0.8f);
			if (text.color.a >= 1)
				fade = true;
		}

		// 프레이어가 화면 터치시 오리가 화면 밖으로 나가고 다음 씬으로 넘어감
		if (!isStart && (Input.touchCount > 0 || Input.anyKeyDown))
		{
			isStart = true;
			StartCoroutine(TouchToStart());
		}
	}

	IEnumerator TouchToStart()
	{
		player.GetComponent<SpriteRenderer>().flipX = true;
		player.GetComponent<BirdCustomAnimation>().isWalking = true;
		while (player.transform.position.x < 6)
		{
			player.transform.Translate(new Vector3(1.5f, 0, 0) * Time.deltaTime);

			yield return null;
		}
		// 다음 씬으로 넘어감
		levelLoader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
