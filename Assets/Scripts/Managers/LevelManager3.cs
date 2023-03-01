using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager3 : MonoBehaviour
{
	[SerializeField] private Tilemap map;
	[SerializeField] private Player player;
	[SerializeField] private Tile tile;
	[SerializeField] private GameObject trampolineTrigger;
	[SerializeField] private bool revealLevel;

	private void Start()
	{
	}

	private void Update()
	{
		for (int i = -9; i <= -4; i++)
			for (int j = -6; j <= -5; j++)
				if (ShouldRetract(i, j, 1))
					RetractTile(i, j, 1);
				else
					PlaceBack(i, j, 1);
		if(trampolineTrigger.GetComponent<SecondTrampolineTrigger>().getActivatedFlag())
		{
			for (int i = -5; i <= -4; i++)
				for (int j = -4; j <= 6; j++)
					if (ShouldRetract(i, j, -1))
						RetractTile(i, j, -1);
					else
						PlaceBack(i, j, 1);
		}
		if(revealLevel)
		{
			for (int i = -3; i <= 8; i++)
				for (int j = 4; j <= 5; j++)
					RetractTile(i, j, 1);
			for(int i = 7; i <= 8; i++)
				for(int j = 5; j >= -6; j--)
					RetractTile(i, j, 1);
		}
	}

	public void RetractTile(int xPos, int yPos, int direction)
	{
		Vector3Int pos = new Vector3Int(xPos, yPos, 0);
		if(map.GetTile(pos) != null)
			map.SetTile(pos, null);
	}

	private bool ShouldRetract(int xPos, int yPos, int direction)
	{
		Vector3 playerPos = player.gameObject.transform.position;

		if (direction == 1)
		{
			if (Mathf.Abs(playerPos.x - xPos) <= 2)
				return true;
		}
		else
		{
			if (Mathf.Abs(playerPos.y - yPos) <= 2)
				return true;
		}

		return false;
	}

	private void PlaceBack(int xPos, int yPos, int direction)
	{
		Vector3Int pos = new Vector3Int(xPos, yPos, 0);
		if (map.GetTile(pos) == null)
			map.SetTile(pos, tile);
	}

	public void setRevealLevelFlag(bool value)
	{
		this.revealLevel = value;
	}
}
