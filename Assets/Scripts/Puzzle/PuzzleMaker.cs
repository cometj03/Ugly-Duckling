using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaker : MonoBehaviour
{
	public enum PUZZLE_TYPE { OUTLINE, TILE };

	Vector3 per_touch_vec;
	Vector3 touch_vec;

	Puzzle puzzle;
	Block block;

	public GameObject tile_prefab;
	public GameObject block_prefab;

	PUZZLE_TYPE puzzle_type;

	private void Awake()
	{
		per_touch_vec = Vector3.zero;
		touch_vec = Vector3.zero;
		puzzle = GameObject.Find("Puzzle").GetComponent<Puzzle>();
		puzzle_type = PUZZLE_TYPE.TILE;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
			touch_vec = Vector3Int.RoundToInt(touch_vec);
			touch_vec.z = 0;

			if (puzzle_type == PUZZLE_TYPE.TILE)
			{
				GameObject tmp = Instantiate(block_prefab);

				tmp.transform.SetParent(puzzle.transform.GetChild(0));
				block = tmp.GetComponent<Block>();
				puzzle.blocks.Add(block);
			}
			else if(puzzle_type == PUZZLE_TYPE.OUTLINE)
			{
				puzzle.outline.Clear();
			}
		}
		else if (Input.GetMouseButton(0))
		{
			per_touch_vec = touch_vec;

			touch_vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
			touch_vec = Vector3Int.RoundToInt(touch_vec);
			touch_vec.z = 0;

			if (touch_vec != per_touch_vec)
			{
				GameObject tmp = Instantiate(tile_prefab);
				if (puzzle_type == PUZZLE_TYPE.TILE)
				{
					tmp.GetComponent<Tile>().tile_type = Tile.TILE_TYPE.TILE;

					tmp.transform.SetParent(block.transform);
					tmp.transform.position = touch_vec;
					tmp.GetComponent<Tile>().x = (int)touch_vec.x;
					tmp.GetComponent<Tile>().y = (int)touch_vec.y;
					block.pushTile(tmp.GetComponent<Tile>());
				}
				else if(puzzle_type == PUZZLE_TYPE.OUTLINE)
				{
					tmp.GetComponent<Tile>().tile_type = Tile.TILE_TYPE.OUTLINE;

					tmp.transform.SetParent(puzzle.outline.transform);
					tmp.transform.position = touch_vec;
					tmp.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Outlines/outline");
					puzzle.outline.tiles.Add(tmp.GetComponent<Tile>());
				}
			}
		}
	}

	public void SetPuzzleTypeTile()
	{
		puzzle_type = PUZZLE_TYPE.TILE;
	}

	public void SetPuzzleTypeOutline()
	{
		puzzle_type = PUZZLE_TYPE.OUTLINE;
	}
}
