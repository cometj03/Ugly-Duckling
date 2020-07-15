using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
	Outline outline;
	List<Block> blocks = new List<Block>();

	public Block pushBlock()
	{
		Block block = new Block();

		blocks.Add(block);

		return block;
	}
}
