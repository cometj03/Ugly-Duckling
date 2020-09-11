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

	SpriteRenderer player;

	private Coroutine doAnim;

	private void Awake()
	{
		idle = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/Idle");
		walk = Resources.LoadAll<Sprite>("Animations/" + PlayerData.Instance.currentSkin + "/Walk");
		player = GetComponent<SpriteRenderer>();

		doAnim = StartCoroutine(DoAnimation());
	}

	public void ChangeSkin(string _skinName)
	{
		PlayerData.Instance.currentSkin = _skinName;
		StopCoroutine(doAnim);
		Awake();
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

			animationPhase++;
			yield return new WaitForSeconds(isWalking ? 0.15f : 0.6f);
		}
	}
}
