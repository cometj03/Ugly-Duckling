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
				perBlockPosition = selectBlock.position;
				perMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
				Vector2 mouseDistance = math.round((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - perMousePosition);

				if (math.abs(mouseDistance.x) + math.abs(mouseDistance.y) > 1)
				{
					return;
				}

				selectBlock.position += mouseDistance;

				if (perBlockPosition != selectBlock.position)
				{
					foreach (var tile in selectBlock.tiles)
					{
						Vector2 tilePosition = tile.position + selectBlock.position;

						int crossCount = 0;

						foreach (var anothertile in selectPuzzle.outline.tiles)
						{
							if (tilePosition.y == anothertile.position.y && tilePosition.x <= anothertile.position.x && anothertile.isConnected.IndexOf("right") == -1)
							{
								crossCount++;
							}

							if (tilePosition == anothertile.position)
							{
								selectBlock.position = perBlockPosition;
								return;
							}
						}

						if (crossCount % 2 == 0)
						{
							selectBlock.position = perBlockPosition;
							return;
						}

						foreach (var block in selectPuzzle.blocks)
						{
							if (block != selectBlock)
							{
								foreach (var anothertile in block.tiles)
								{
									Vector2 anothertilePosition = anothertile.position + block.position;

									if (tilePosition == anothertilePosition)
									{
										selectBlock.position = perBlockPosition;
										return;
									}
								}
							}
						}

						if (tilePosition.x - 0.5f < player.transform.position.x && player.transform.position.x < tilePosition.x + 0.5f &&
						tilePosition.y - 0.5f < player.transform.position.y && player.transform.position.y < tilePosition.y + 0.5f)
						{
							selectBlock.position = perBlockPosition;
							return;
						}
					}

					perMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					perBlockPosition = selectBlock.position;

					GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX(eSFX.BlockMove);
				}
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
