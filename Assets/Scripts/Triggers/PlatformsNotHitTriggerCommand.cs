using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformsNotHitTriggerCommand : MonoBehaviour
{
	[SerializeField] private Tilemap tilemap;

	private void DeleteFloor()
	{
		for(int i = -6; i <= 13; i++)
		{
			Vector3Int position = new Vector3Int(i, -32, 0);
			tilemap.SetTile(position, null);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Player>() != null)
		{
			if (LevelManager5.platformsHit < 14)
				DeleteFloor();
		}
	}
}
