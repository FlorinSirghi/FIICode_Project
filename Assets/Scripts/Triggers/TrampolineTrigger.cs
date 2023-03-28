using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
			Vector2 force = new Vector2(0, 100f);
			rigidbody2D.AddForce(force, ForceMode2D.Impulse);
			this.gameObject.SetActive(false);
		}
	}
}
