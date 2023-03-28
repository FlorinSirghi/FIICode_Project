using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon2 : MonoBehaviour
{
	// Events
	public event EventHandler OnShoot;

	// References

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject battleManager;
	private Transform aimTransform;
	private Animator animator;

	private void Awake()
	{
		aimTransform = transform.Find("Aim");
		animator = aimTransform.GetComponent<Animator>();
	}

	private void Update()
	{
		Aim();
		Shoot();
	}

	private void Aim()
	{
		Vector3 mousePosition = GetMousePosition();

		Vector3 aimDirection = (mousePosition - transform.position).normalized;
		float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

		if (player.transform.localScale.x == 1)
		{
			if (angle > 90)
				angle = 90;
			else if (angle < -90)
				angle = -90;
		}
		else
		{
			if (angle < 90 && angle > 0)
				angle = 90;
			else if (angle > -90 && angle < 0)
				angle = -90;
			if (angle > 0)
				angle = angle - 180;
			else
				angle = 180 + angle;
		}

		aimTransform.eulerAngles = new Vector3(0, 0, angle);
	}

	private void Shoot()
	{
		if (Input.GetMouseButtonDown(0))
		{
			animator.SetTrigger("Shoot");
			BattleManager battleManagerScript = battleManager.GetComponent<BattleManager>();
			if (player.transform.localScale.x == 1)
			{
				OnShoot?.Invoke(this, EventArgs.Empty);
			}
			else
			{
				OnShoot?.Invoke(this, EventArgs.Empty);
			}

		}
	}

	public static Vector3 GetMousePosition()
	{
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		worldPosition.z = 0f;
		return worldPosition;
	}
}
