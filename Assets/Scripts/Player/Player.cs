using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	// References
	[SerializeField] private LayerMask platformLayerMask;
	[SerializeField] private GameInput gameInput;
	[SerializeField] private Rigidbody2D rigidBody2D;
	[SerializeField] private BoxCollider2D boxCollider2D;

	// Fields
	[SerializeField] private float movementSpeed = 10.0f;
	[SerializeField] private float jumpVelocity = 10.0f;

	private void Awake()
	{
		rigidBody2D = this.GetComponent<Rigidbody2D>();
		boxCollider2D = this.GetComponent <BoxCollider2D>();
	}

	private void Update()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		// Left-Right Movement
		Vector2 inputVector = gameInput.GetMovementVector();

		Vector3 movementDirection = Vector3.zero;

		movementDirection = new Vector3(inputVector.x, 0.0f, 0.0f);

		transform.position += movementDirection * Time.deltaTime * movementSpeed;
	}

	public void Jump(InputAction.CallbackContext context)
	{
		if (context.performed && IsGrounded())
			rigidBody2D.velocity = Vector2.up * jumpVelocity;
	}

	public bool IsGrounded()
	{
		float extraHeightTest = .5f;
		RaycastHit2D rayCastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, platformLayerMask);

		return rayCastHit2D.collider != null;
	}
}
