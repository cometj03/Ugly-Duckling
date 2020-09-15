using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BirdCustomAnimation : MonoBehaviour
{
	int animationPhase = 0;
	public bool isWalking = false;

    Sprite[] idle;
    Sprite[] walk;
	Sprite[] fallDown;

	SpriteRenderer player;

	private GameManager _gameManager;
	private Coroutine co_doAnim;
	private bool isGameScene;

	private void Start()
	{
		idle = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/Idle");
		walk = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/Walk");
		player = GetComponent<SpriteRenderer>();

		if (FindObjectOfType<GameManager>() != null)
		{
			isGameScene = true;
			_gameManager = FindObjectOfType<GameManager>();
		}

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
		fallDown = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/FallDown");
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

			if (isGameScene && _gameManager.currentState == GameState.OVER)
			{
				PlayFallDown();
				break;
			}

			animationPhase++;
			yield return new WaitForSeconds(isWalking ? 0.15f : 0.6f);
		}
	}
}
