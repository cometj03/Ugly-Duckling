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
	public GameObject tile;

	public List<List<Tile>> grid;

	public void TilePreview()
	{
		preview.transform.position = (Vector2)math.round((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	private void Update()
	{
		TilePreview();

		if (Input.GetMouseButtonDown(0))
		{
			GameObject tmp = Instantiate(tile);

			tmp.transform.position = preview.transform.position;
			tmp.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Tiles/tile");
		}
	}
}
