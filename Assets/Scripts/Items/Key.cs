using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public event EventHandler OnKeyPickUp;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponent<Player>() != null)
		{
			Destroy(this.gameObject);
			OnKeyPickUp?.Invoke(this, EventArgs.Empty);
		}
	}
}
