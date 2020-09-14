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
	
	private bool fade = true;   // touch to start 가 흐려지게 하건지 뚜렷해지게 할건지 여부

	private void Update()
	{
		// touch to start가 깜박거리는 효과를 주는 코드
		if (fade)
		{
			var color = text.color;
			text.color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime * 0.8f);
			if (text.color.a <= 0.4f)
				fade = false;
		}
		else
		{
			var color = text.color;
			text.color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime * 0.8f);
			if (text.color.a >= 1)
				fade = true;
		}
		
		if (Application.platform == RuntimePlatform.Android)
			if (Input.GetKey(KeyCode.Escape))
				Application.Quit();
	}

	public void TouchBtn() => StartCoroutine(TouchToStart());

	
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
		FindObjectOfType<LevelLoader>().LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
