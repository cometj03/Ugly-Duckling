using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
	/// <summary>
	/// 메인화면에서 필요한 모든 조작을 담당함
	/// </summary>

	public Text text; //touch to start Text
	public GameObject player; //오리 객체 

	private bool fade = true; //touch to start 가 흐려지게 하건지 뚜렷해지게 할건지 여부

	private void Update()
	{
		///touch to start가 깜박거리는 효과를 주는 코드
		if (fade)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.005f);
			if (text.color.a <= 0)
				fade = false;
		}
		else
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + 0.005f);
			if (text.color.a >= 1)
				fade = true;
		}

		///프레이어가 화면 터치시 오리가 화면 밖으로 나가고 다음 씬으로 넘어감
		if (Input.touchCount > 0 || Input.anyKeyDown)
		{
			StartCoroutine(TouchToStart());
		}
	}

	IEnumerator TouchToStart()
	{
		player.GetComponent<SpriteRenderer>().flipX = true;
		player.GetComponent<Animator>().SetBool("is_walk", true);
		while (player.transform.position.x < 6)
		{
			player.transform.Translate(new Vector3(0.01f, 0, 0));
			yield return new WaitForEndOfFrame();
		}
		//다음 씬으로 넘어감
	}
}
