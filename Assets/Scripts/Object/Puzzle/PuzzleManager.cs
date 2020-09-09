﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
	public GameObject block;
	public GameObject previewTile;

	public GameObject jumpObject;
	public GameObject moveObject;
	public GameObject player;

	Image jumpImage;
	Image moveImage;

	Button jumpButton;
	HorizontalButton moveButton;

	Vector2 perBlockposition;
	Vector2 mouseBlockDIstance;

	Puzzle selectPuzzle;
	Block previewBlock;
	Block selectBlock;

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

				jumpImage.color = new Color(0.5f, 0.5f, 0.5f);
				moveImage.color = new Color(0.5f, 0.5f, 0.5f);

				jumpButton.enabled = false;
				moveButton.enabled = false;

				previewBlock = Instantiate(block).GetComponent<Block>();

				foreach (var tile in selectBlock.tiles)
				{
					Tile tmp = Instantiate(previewTile).GetComponent<Tile>();

					tmp.transform.position = tile.transform.localPosition + selectPuzzle.transform.localPosition;
					tmp.transform.SetParent(previewBlock.transform);

					previewBlock.Insert(tmp);
				}
			}
		}
		if (selectPuzzle)
		{
			if (Input.GetMouseButton(0))
			{
				previewBlock.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseBlockDIstance;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				jumpImage.color = new Color(1, 1, 1);
				moveImage.color = new Color(1, 1, 1);

				jumpButton.enabled = true;
				moveButton.enabled = true;

				selectBlock.transform.localPosition = (Vector2)math.round((Vector2)previewBlock.transform.localPosition);
				Destroy(previewBlock.gameObject);

				foreach (var tile in selectBlock.tiles)
				{
					Vector2 tilePosition = tile.transform.localPosition + selectBlock.transform.localPosition;

					if (tilePosition.x - 0.5f < player.transform.position.x && player.transform.position.x < tilePosition.x + 0.5f &&
						tilePosition.y - 0.5f < player.transform.position.y && player.transform.position.y < tilePosition.y + 0.5f)
					{
						selectBlock.transform.localPosition = perBlockposition;
						selectPuzzle = null;
						selectBlock = null;
						return;
					}

					int scrossPoint = 0;

					foreach (var outlinetile in selectPuzzle.outline.tiles)
					{
						if (tilePosition.y == outlinetile.transform.localPosition.y && tilePosition.x <= outlinetile.transform.localPosition.x)
						{
							scrossPoint++;
						}
						if(tilePosition == (Vector2)outlinetile.transform.localPosition)
						{
							selectBlock.transform.localPosition = perBlockposition;
							selectPuzzle = null;
							selectBlock = null;
							return;
						}
					}

					if (scrossPoint % 2 == 0)
					{
						selectBlock.transform.localPosition = perBlockposition;
						selectPuzzle = null;
						selectBlock = null;
						return;
					}
				}

				foreach (var block in selectPuzzle.blocks)
				{
					if (block != selectBlock)
					{
						foreach (var tile in selectBlock.tiles)
						{
							Vector2 tilePosition = tile.transform.localPosition + selectBlock.transform.localPosition;
							foreach (var anotertile in block.tiles)
							{
								Vector2 anotertilePosition = anotertile.transform.localPosition + block.transform.localPosition;
								if (tilePosition == anotertilePosition)
								{
									selectBlock.transform.localPosition = perBlockposition;
									selectPuzzle = null;
									selectBlock = null;
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

	private void Awake()
	{
		jumpImage = jumpObject.GetComponent<Image>();
		jumpButton = jumpObject.GetComponent<Button>();
		moveImage = moveObject.GetComponent<Image>();
		moveButton = moveObject.GetComponent<HorizontalButton>();
	}

	private void Update()
	{
		PuzzleMovement();
	}
}
