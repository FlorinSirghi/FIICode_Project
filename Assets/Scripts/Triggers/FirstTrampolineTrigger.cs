using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrampolineTrigger : MonoBehaviour
{
	[SerializeField] private GameObject levelManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			levelManager.GetComponent<LevelManager3>().RetractTile(-5, -4, 1);
			levelManager.GetComponent<LevelManager3>().RetractTile(-4, -4, 1);
		}
	}
}
