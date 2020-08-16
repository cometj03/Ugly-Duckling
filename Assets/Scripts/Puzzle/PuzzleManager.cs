using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Mathematics;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
	public enum TILE_TYPE { OUTLINE, BLOCK, AIR };

	public TILE_TYPE type;

	public GameObject preview;
	public GameObject puzzle;
	public GameObject tile;
	public GameObject block;

	public GameObject writingblock;

	public List<List<Tile>> grid;

	Vector2 perPreviewPos;

	public void TilePreview()
	{
		preview.transform.position = (Vector2)math.round((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public void WriteBlock()
	{
		if (Input.GetMouseButtonDown(0))
		{
			writingblock = Instantiate(block);
		}
		else if (Input.GetMouseButton(0))
		{
			if (perPreviewPos != (Vector2)preview.transform.position)
			{

			}
		}
		else if (Input.GetMouseButtonUp(0))
		{

		}
	}

	private void Update()
	{
		TilePreview();

		if (type == TILE_TYPE.BLOCK)
		{
			WriteBlock();
		}

		perPreviewPos = preview.transform.position;
	}
}
