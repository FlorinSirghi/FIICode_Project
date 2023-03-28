using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager2 : MonoBehaviour
{
	[SerializeField] private HealthBar playerHealthBar;
	[SerializeField] private HealthBar bossHealthBar;
	[SerializeField] private GameObject player;

	HealthManager healthManagerPlayer;
	HealthManager healthManagerBoss;

	private void Start()
	{
		healthManagerPlayer = new HealthManager(100);

		playerHealthBar.Setup(healthManagerPlayer);

		healthManagerBoss = new HealthManager(300);

		bossHealthBar.Setup(healthManagerBoss);

		player.GetComponent<AimWeapon2>().OnShoot += AimWeapon2_OnShoot;
	}

	private void AimWeapon2_OnShoot(object sender, System.EventArgs e)
	{
		healthManagerBoss.Damage(10);
	}
}
