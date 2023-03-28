using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAI : MonoBehaviour
{
	
	// Animation flags
	const string WALKING = "Walking";
	const string ATTACK1 = "Attack1";
	const string ATTACK2 = "Attack2";
	const string ATTACK3 = "Attack3";

	// References
    [SerializeField] private Animator animator;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject playerHealthBar;
	[SerializeField] private LayerMask playerLayerMask;
	[SerializeField] private float movementSpeed = 20f;

	// Fields
    private float nextMoveTime = 3.0f;
	private float movePeriod = 2f;
    private float idlePeriod = 5f;
	private float nextIdleTime = 3.0f;
	private bool modifiedMoveTime = false;
	private bool modifiedIdleTime = false;

    void Update()
    {
        if(Time.time > nextIdleTime)
		{
			if (modifiedMoveTime == false)
			{
				nextMoveTime = Time.time + movePeriod;
				modifiedMoveTime = true;
				modifiedIdleTime = false;
			}
			animator.SetBool(WALKING, true);
            Move(true);
		}
		if(Time.time > nextMoveTime)
		{
			if (modifiedIdleTime == false)
			{
				nextIdleTime = Time.time + idlePeriod;
				modifiedIdleTime = true;
				modifiedMoveTime = false;

				//int randomAttack = Random.Range(0, 3);
				int randomAttack = 0;

				switch(randomAttack)
				{
					case 0:
						Attack1();
						break;
					case 1:
						Attack2();
						break;
					case 2:
						Attack3();
						break;
				}
			}
			animator.SetBool(WALKING, false);
			Move(false);
		}
	}

	private void Move(bool shouldMove)
	{
		if (shouldMove)
		{
			Transform currentTransform = this.transform;

			Vector3 movementDirection = Vector3.zero;

			if (player.transform.position.x > this.transform.position.x)
				movementDirection = Vector3.right;
			else if (player.transform.position.x < this.transform.position.x)
				movementDirection = Vector3.left;
			else
				movementDirection = Vector3.zero;

			if (movementDirection.x > 0.0f)
				this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			else if (movementDirection.x < 0.0f)
				this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

			transform.position += movementDirection * Time.deltaTime * movementSpeed;
		}
	}

	private void Attack1()
	{
		if(this.transform.localScale.x == 1)
		{	
			if(Physics2D.Raycast(transform.position, Vector3.right, 5f, playerLayerMask))
			{
				Debug.Log((Physics2D.Raycast(transform.position, Vector3.right, 5f, playerLayerMask).collider.gameObject.name));
				playerHealthBar.GetComponent<HealthBar>().getHealthManagerPlayer().Damage(30);
			}
		}

		if (this.transform.localScale.x == -1)
		{
			if (Physics2D.Raycast(transform.position, Vector3.left, 5f, playerLayerMask))
			{
				Debug.Log((Physics2D.Raycast(transform.position, Vector3.left, 5f, playerLayerMask).collider.gameObject.name));
				playerHealthBar.GetComponent<HealthBar>().getHealthManagerPlayer().Damage(30);
			}
		}

		animator.SetTrigger(ATTACK1);
	}

	private void Attack2()
	{
		animator.SetTrigger(ATTACK2);
	}

	private void Attack3()
	{
		animator.SetTrigger(ATTACK3);
	}
}
