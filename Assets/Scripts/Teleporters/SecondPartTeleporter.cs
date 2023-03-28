using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPartTeleporter : MonoBehaviour
{
	[SerializeField] private Player player;

	Vector3 secondPartStartPosition = new Vector3(-19f, -10f, 0.0f);

	private void OnTriggerEnter2D(Collider2D collision)
	{
		player.transform.position = secondPartStartPosition;
	}
}
