using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<Player>() != null)
			collision.gameObject.SetActive(false);
	}
}
