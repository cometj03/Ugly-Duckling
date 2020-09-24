using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class BirdCustomAnimation : MonoBehaviour
{
	int animationPhase = 0;
	public bool isWalking = false;

    Sprite[] idle;
    Sprite[] walk;
	Sprite[] fallDown;

	SpriteRenderer player;

	private Coroutine co_doAnim;
	private bool isGameScene;

	private void Start()
	{
		idle = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/Idle");
		walk = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/Walk");
		fallDown = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/FallDown");
		player = GetComponent<SpriteRenderer>();

		isGameScene = SceneManager.GetActiveScene().buildIndex >= 2;

		co_doAnim = StartCoroutine(DoAnimation());
	}

	public void ChangeSkin(string _skinName)
	{
		PlayerData.Instance.currentSkin = _skinName;
		StopCoroutine(co_doAnim);
		Start();
	}

	private void PlayFallDown()
	{
		StartCoroutine(DoFallDown());
	}

	IEnumerator DoFallDown()
	{
		foreach (Sprite sp in fallDown)
		{
			player.sprite = sp;
			yield return new WaitForSeconds(0.2f);
		}
	}

	IEnumerator DoAnimation()
	{
		while (true)
		{
			if(animationPhase > (isWalking ? walk : idle).Length - 1)
			{
				animationPhase = 0;
			}

			if (isWalking)
			{
				player.sprite = walk[animationPhase];
			}
			else
			{
				player.sprite = idle[animationPhase];
			}

			if (isGameScene && PlayerData.Instance.currentState == GameState.OVER)
			{
				PlayFallDown();
				break;
			}

			animationPhase++;
			yield return new WaitForSeconds(isWalking ? 0.15f : 0.6f);
		}
	}
}
