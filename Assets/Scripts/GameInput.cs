using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
	PlayerInputActions playerInputActions;

	private void Awake()
	{
		playerInputActions = new PlayerInputActions();
		playerInputActions.Player.Enable();
	}

	public Vector2 GetMovementVector()
	{
		Vector2 movementVector = playerInputActions.Player.Move.ReadValue<Vector2>();

		movementVector.Normalize();

		return movementVector;
	}
}
