using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMaker : MonoBehaviour
{
	public InputField puzzleNumber;
	public PuzzleLoader puzzleLoader;

	public GameObject puzzleNumber_Panel;

	public void PuzzleLoad()
	{
		puzzleLoader.FileToPuzzle("newPuzzle" + puzzleNumber.text);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			puzzleNumber_Panel.SetActive(true);
		}
	}
}
