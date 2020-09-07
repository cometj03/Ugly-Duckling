using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BirdCustomAnimation : MonoBehaviour
{
    public string skinName;

	int animationPhase = 0;
	public bool isWalking = false;

    Sprite[] idle;
	Sprite[] walk;

	SpriteRenderer player;

	private void Awake()
	{
		idle = Resources.LoadAll<Sprite>("Animations/" + skinName + "/Idle");
		walk = Resources.LoadAll<Sprite>("Animations/" + skinName + "/Walk");
		player = GetComponent<SpriteRenderer>();

		StartCoroutine(DoAnimation());
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
			yield return new WaitForSeconds(isWalking ? 0.1f : 0.3f);
		}
	}
}
