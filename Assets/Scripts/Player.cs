using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// References
	[SerializeField] private GameInput gameInput;

	// Fields
	[SerializeField] private float movementSpeed = 10.0f;
	[SerializeField] private float jumpHeight = 3.0f;

	private void Update()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		// Left-Right Movement
		Vector2 inputVector = gameInput.GetMovementVector();

		// Jumping
		bool jumpingFlag = gameInput.GetJumpingFlag();

		Vector3 movementDirection = Vector3.zero;

		if (!jumpingFlag)
			movementDirection = new Vector3(inputVector.x, 0.0f, 0.0f);
		else
			movementDirection = new Vector3(inputVector.x, jumpHeight, 0.0f);

		transform.position += movementDirection * Time.deltaTime * movementSpeed;
	}
}
