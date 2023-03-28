using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
	// Events

	public event EventHandler OnZombieDead;

	// Animation names
	const string DEAD = "Dead";

	// References
	[SerializeField] private HealthBar healthBar;
	private GameObject player;
	private Animator animator;
	private HealthManager healthManager;

	// Fields
	private float movementSpeed = 3;
	private bool dead = false;
	private Vector3 movementDirection;

	private void Awake()
	{
		player = GameObject.Find("Player");
	}

	private void Start()
	{
		animator = GetComponent<Animator>();
		OnZombieDead += ZombieBehaviour_OnZombieDead;

		healthManager = new HealthManager(100);
		healthBar.Setup(healthManager);

		AimWeapon aimWeapon = player.GetComponent<AimWeapon>();
		aimWeapon.OnShoot += AimWeapon_OnShoot;
	}

	public void Update()
	{
		if (!dead)
		{
			this.transform.position += movementDirection * Time.deltaTime * movementSpeed;
		}
		if (healthManager.GetHealth() == 0)
		{
			OnZombieDead(this, EventArgs.Empty);
		}
		if(CanAttack())
		{
			Attack();
		}
	}

	private void AimWeapon_OnShoot(object sender, AimWeapon.OnShootEventArgs e)
	{
		if(e.hitZombie == this.gameObject)
			healthManager.Damage(40);
	}
	public void Spawn()
	{
		this.gameObject.SetActive(true);
	}

	private void ZombieBehaviour_OnZombieDead(object sender, System.EventArgs e)
	{
		animator.SetBool(DEAD, true);
		dead = true;
		this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		Destroy(gameObject, 5);
	}
	public void setMovementDirection(Vector3 dir)
	{
		movementDirection = dir;
	}
	public bool getDeadFlag()
	{
		return dead;
	}
	private bool CanAttack()
	{
		float distanceBetweenPlayerAndZombie = Mathf.Abs(this.transform.position.x - player.transform.position.x);
		return distanceBetweenPlayerAndZombie < 0.5f ? true : false;
	}
	private void Attack()
	{
		Debug.Log("Attack");
	}
}
