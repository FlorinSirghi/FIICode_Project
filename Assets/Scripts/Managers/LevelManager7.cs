using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager7 : MonoBehaviour
{
	[SerializeField] private GameObject player;

	public HealthBar healthBar;

	private HealthManager healthManagerPlayer;

	private void Start()
	{
		healthManagerPlayer = new HealthManager(100);

		healthBar.Setup(healthManagerPlayer);
	}
}
