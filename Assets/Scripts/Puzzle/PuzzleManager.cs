using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleManager : MonoBehaviour
{
	Vector2 perBlockposition;
	Vector2 mouseBlockDIstance;

	Puzzle selectPuzzle;
	Block selectBlock;

    List<Puzzle> puzzles = new List<Puzzle>();

    public void Push(Puzzle puzzle)
	{
		puzzles.Add(puzzle);
	}

	public void PuzzleMovement()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit && hit.transform.tag == "Tile")
			{
				selectPuzzle = hit.transform.parent.parent.GetComponent<Puzzle>();
				selectBlock = hit.transform.parent.GetComponent<Block>();
				perBlockposition = selectBlock.transform.position;
				mouseBlockDIstance = selectBlock.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		else if (Input.GetMouseButton(0))
		{
			selectBlock.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseBlockDIstance;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			selectBlock.transform.position = (Vector2)math.round((Vector2)selectBlock.transform.position);

			foreach(var tile in selectBlock.tiles)
			{
				int scrossPoint = 0;

				foreach(var outlinetile in selectPuzzle.outline.tiles)
				{
					if(tile.transform.position.y == outlinetile.transform.position.y && tile.transform.position.x <= outlinetile.transform.position.x)
					{
						scrossPoint++;
					}
				}

				if(scrossPoint % 2 == 0)
				{
					selectBlock.transform.position = perBlockposition;
					return;
				}
			}

			foreach(var block in selectPuzzle.blocks)
			{
				if(block != selectBlock)
				{
					foreach(var tile in selectBlock.tiles)
					{
						foreach(var anotertile in block.tiles)
						{
							if(tile.transform.position == anotertile.transform.position)
							{
								selectBlock.transform.position = perBlockposition;
								return;
							}
						}
					}
				}
			}
		}
	}

	private void Update()
	{
		PuzzleMovement();
	}
}
