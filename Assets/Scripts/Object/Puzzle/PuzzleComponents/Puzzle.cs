using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
	public Outline outline;
	public List<Block> blocks { get; } = new List<Block>();

	private void Awake()
	{
		outline = transform.GetChild(1).GetComponent<Outline>();
	}
}
