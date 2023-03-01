using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTrampolineTrigger : MonoBehaviour
{
	private bool activated = false;

	Player player;

	private void FixedUpdate()
	{
		if(activated && player.IsGrounded())
		{
			Debug.Log("Caca");
			Rigidbody2D rigidbody2D = player.gameObject.GetComponent<Rigidbody2D>();
			Vector2 force = new Vector2(0, 100f);
			rigidbody2D.AddForce(force, ForceMode2D.Impulse);
			//activated = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.GetComponent<Player>() != null)
		{
			activated = true;
			player = collision.gameObject.GetComponent<Player>();
			this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	public bool getActivatedFlag()
	{
		return activated;
	}

	public void setActivatedFlag(bool value)
	{
		this.activated = value;
	}
}
