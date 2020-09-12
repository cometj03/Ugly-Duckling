using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
	public GameObject jumpObject;
	public GameObject moveObject;
	public GameObject player;

	Image jumpImage;
	Image moveImage;

	Button jumpButton;
	HorizontalButton moveButton;

	Vector2 perBlockPosition;
	Vector2 perMousePosition;

	Puzzle selectPuzzle;
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
				perBlockPosition = selectBlock.transform.localPosition;
				perMousePosition = math.round((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));

				jumpImage.color = new Color(0.5f, 0.5f, 0.5f);
				moveImage.color = new Color(0.5f, 0.5f, 0.5f);

				jumpButton.enabled = false;
				moveButton.enabled = false;
			}
		}
		if (selectPuzzle)
		{
			if (Input.GetMouseButton(0))
			{
				selectBlock.transform.localPosition += (Vector3)(Vector2)math.round((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - perMousePosition);

				if (perBlockPosition != (Vector2)selectBlock.transform.localPosition)
				{
					foreach (var tile in selectBlock.tiles)
					{
						Vector2 tilePosition = tile.transform.localPosition + selectBlock.transform.localPosition;

						int crossCount = 0;

						foreach (var anothertile in selectPuzzle.outline.tiles)
						{

							if (tilePosition.y == anothertile.transform.localPosition.y && tilePosition.x <= anothertile.transform.localPosition.x)
							{
								crossCount++;
							}

							if (tilePosition == (Vector2)anothertile.transform.localPosition)
							{
								selectBlock.transform.localPosition = perBlockPosition;
								return;
							}
						}

						if(crossCount % 2 == 0)
						{
							selectBlock.transform.localPosition = perBlockPosition;
							return;
						}

						foreach (var block in selectPuzzle.blocks)
						{
							if (block != selectBlock)
							{
								foreach (var anothertile in block.tiles)
								{
									Vector2 anothertilePosition = anothertile.transform.localPosition + block.transform.localPosition;

									if (tilePosition == anothertilePosition)
									{
										selectBlock.transform.localPosition = perBlockPosition;
										return;
									}
								}
							}
						}

						if (tilePosition.x - 0.5f < player.transform.position.x && player.transform.position.x < tilePosition.x + 0.5f &&
						tilePosition.y - 0.5f < player.transform.position.y && player.transform.position.y < tilePosition.y + 0.5f)
						{
							selectBlock.transform.localPosition = perBlockPosition;
							return;
						}
					}

					perMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				}

				perBlockPosition = selectBlock.transform.localPosition;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				jumpImage.color = new Color(1, 1, 1);
				moveImage.color = new Color(1, 1, 1);

				jumpButton.enabled = true;
				moveButton.enabled = true;

				selectBlock = null;
				selectPuzzle = null;
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
