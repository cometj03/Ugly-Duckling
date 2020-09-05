using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    List<Puzzle> puzzles = new List<Puzzle>();

    public void Push(Puzzle puzzle)
	{
		puzzles.Add(puzzle);
	}

	private void Update()
	{
		
	}
}
