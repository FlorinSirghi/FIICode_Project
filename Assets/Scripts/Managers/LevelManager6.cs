using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager6 : MonoBehaviour
{
    [SerializeField] private GameObject player;
	[SerializeField] private GameObject leverObject;
	private Collider2D lever = null;

	private void Update()
	{
		lever = player.GetComponent<Player>().DetectInteractions();
		if(lever != null)
		{
			leverObject.GetComponent<Lever>().leverSwitched();
			lever = null;
		}
	}
}
