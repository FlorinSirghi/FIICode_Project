using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
	// Animation states
	const string RUNNING = "Running";
	const string JUMPING = "Jumping";

	// References
	[SerializeField] private LayerMask platformLayerMask;
	[SerializeField] private GameInput gameInput;
	[SerializeField] private Rigidbody2D rigidBody2D;
	[SerializeField] private BoxCollider2D boxCollider2D;
	[SerializeField] private Animator animator;
	[SerializeField] private LayerMask objectsLayerMask;

	// Fields
	[SerializeField] private float movementSpeed = 10.0f;
	[SerializeField] private float jumpVelocity = 10.0f;
	private bool moving;

	private void Awake()
	{
		rigidBody2D = this.GetComponent<Rigidbody2D>();
		boxCollider2D = this.GetComponent <BoxCollider2D>();
		animator = this.GetComponent<Animator>();
		moving = false;
	}

	private void Update()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		// Left-Right Movement

		Transform currentTransform = this.transform;

		Vector2 inputVector = gameInput.GetMovementVector();

		Vector3 movementDirection = Vector3.zero;

		movementDirection = new Vector3(inputVector.x, 0.0f, 0.0f);

		if(movementDirection.sqrMagnitude > 0.0f)
		{
			animator.SetBool(RUNNING, true);
			moving = true;
		}
		else
		{
			animator.SetBool(RUNNING, false);
			moving = false;
		}

		if(movementDirection.x > 0.0f)
			this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		else if(movementDirection.x < 0.0f)
			this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

		transform.position += movementDirection * Time.deltaTime * movementSpeed;
	}

	public void Jump(InputAction.CallbackContext context)
	{
		if (context.performed && IsGrounded())
		{
			rigidBody2D.velocity = Vector2.up * jumpVelocity;
			animator.SetBool(JUMPING, true);
		}
		else
		{
			animator.SetBool(JUMPING, false);
		}
	}

	public bool IsGrounded()
	{
		float extraHeightTest = .5f;
		RaycastHit2D rayCastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, platformLayerMask);

		return rayCastHit2D.collider != null;
	}

	public Collider2D DetectInteractions()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			float interactRange = 2f;
			Vector2 direction = new Vector2(transform.localScale.x, 0.0f);
			RaycastHit2D raycast = Physics2D.Raycast(this.transform.position, direction, interactRange, objectsLayerMask);
			return raycast.collider;
		}
		return null;
	}

	public bool getMovingFlag()
	{
		return moving;
	}
}
