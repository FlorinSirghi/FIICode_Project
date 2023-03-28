using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private Vector3 nextPartPosition;
	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		player.transform.position = nextPartPosition;
	}
}

