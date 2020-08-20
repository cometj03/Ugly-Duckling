using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public GameObject runningscene;

	private void OnTriggerStay2D(Collider2D collision)
	{
		runningscene.GetComponent<RunningScene>().can_jump = true;
	}
}
