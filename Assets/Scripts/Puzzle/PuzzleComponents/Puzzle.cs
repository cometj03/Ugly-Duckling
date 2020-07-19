using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
	Outline outline;
	List<Block> blocks = new List<Block>();

	private void Awake()
	{
		outline = transform.GetChild(1).GetComponent<Outline>();
	}

	public void pushBlock(Block block)
	{
		blocks.Add(block);
	}
}
