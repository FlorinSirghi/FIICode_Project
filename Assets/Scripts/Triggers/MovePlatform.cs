using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
	[SerializeField] private GameObject player;

	float speed = 2.5f;

	private void Update()
	{
		if(player.GetComponent<GrapplingHook>().getMovePlatformFlag())
		{
			this.transform.position += Vector3.up * Time.deltaTime * speed;
		}
	}
}
