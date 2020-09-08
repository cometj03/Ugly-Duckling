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
				perBlockposition = selectBlock.transform.localPosition;
				mouseBlockDIstance = selectBlock.transform.localPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		if (selectPuzzle)
		{
			if (Input.GetMouseButton(0))
			{
				selectBlock.transform.localPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseBlockDIstance;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				selectBlock.transform.localPosition = (Vector2)math.round((Vector2)selectBlock.transform.localPosition);

				foreach (var tile in selectBlock.tiles)
				{
					int scrossPoint = 0;

					foreach (var outlinetile in selectPuzzle.outline.tiles)
					{
						Vector2 tilePosition = tile.transform.localPosition + selectBlock.transform.localPosition;
						if (tilePosition.y == outlinetile.transform.localPosition.y && tilePosition.x <= outlinetile.transform.localPosition.x)
						{
							scrossPoint++;
						}
					}

					if (scrossPoint % 2 == 0)
					{
						selectBlock.transform.localPosition = perBlockposition;
						return;
					}
				}

				foreach (var block in selectPuzzle.blocks)
				{
					if (block != selectBlock)
					{
						foreach (var tile in selectBlock.tiles)
						{
							foreach (var anotertile in block.tiles)
							{
								Vector2 tilePosition = tile.transform.localPosition + selectBlock.transform.localPosition;
								Vector2 anotertilePosition = anotertile.transform.localPosition + block.transform.localPosition;
								if (tilePosition == anotertilePosition)
								{
									selectBlock.transform.localPosition = perBlockposition;
									return;
								}
							}
						}
					}
				}

				selectPuzzle = null;
				selectBlock = null;
			}
		}
	}

	private void Update()
	{
		PuzzleMovement();
	}
}
