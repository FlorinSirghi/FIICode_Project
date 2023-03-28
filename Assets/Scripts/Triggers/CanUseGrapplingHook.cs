using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanUseGrapplingHook : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			collision.GetComponent<GrapplingHook>().enabled = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.GetComponent<Player>() != null)
		{
			other.GetComponent<GrapplingHook>().enabled = true;
		}
	}
}
