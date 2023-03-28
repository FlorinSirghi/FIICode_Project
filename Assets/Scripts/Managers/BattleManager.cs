using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
	// Animation flags

	const string RIGHT = "Right";

	// References

	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject key;

	// Fields

	private Vector3 enemyPos1 = new Vector3(12.0f, -4.17f, 0.0f);
	private Vector3 enemyPos2 = new Vector3(13.0f, -4.17f, 0.0f);
	private Vector3 enemyPos3 = new Vector3(-12.0f, -4.17f, 0.0f);
	private Vector3 enemyPos4 = new Vector3(-13.0f, -4.17f, 0.0f);

	private Queue<GameObject> queueLeft = new Queue<GameObject>();
	private Queue<GameObject> queueRight = new Queue<GameObject>();

	private void Start()
	{
		key.GetComponent<Key>().OnKeyPickUp += BattleManager_OnKeyPickUp;
	}

	private void Update()
	{
		if(queueLeft.Count != 0 && queueLeft.Peek().gameObject.GetComponent<ZombieBehaviour>().getDeadFlag())
			queueLeft.Dequeue();
		if(queueRight.Count != 0 && queueRight.Peek().gameObject.GetComponent<ZombieBehaviour>().getDeadFlag())
			queueRight.Dequeue();
	}

	private void BattleManager_OnKeyPickUp(object sender, System.EventArgs e)
	{
		StartBattle();
	}

	private void StartBattle()
	{
		GameObject enemy1 = Instantiate(enemyPrefab, enemyPos1, Quaternion.identity);
		enemy1.GetComponent<ZombieBehaviour>().setMovementDirection(Vector3.left);
		enemy1.GetComponent<ZombieBehaviour>().Spawn();

		queueRight.Enqueue(enemy1);

		GameObject enemy2 = Instantiate(enemyPrefab, enemyPos2, Quaternion.identity);
		enemy2.GetComponent<ZombieBehaviour>().setMovementDirection(Vector3.left);
		enemy2.GetComponent<ZombieBehaviour>().Spawn();

		queueRight.Enqueue(enemy2);

		GameObject enemy3 = Instantiate(enemyPrefab, enemyPos3, Quaternion.identity);
		enemy3.gameObject.transform.localScale = new Vector3(1, 1, 1);
		enemy3.GetComponent<ZombieBehaviour>().setMovementDirection(Vector3.right);
		enemy3.GetComponent<ZombieBehaviour>().Spawn();

		queueLeft.Enqueue(enemy3);

		GameObject enemy4 = Instantiate(enemyPrefab, enemyPos4, Quaternion.identity);
		enemy4.gameObject.transform.localScale = new Vector3(1, 1, 1);
		enemy4.GetComponent<ZombieBehaviour>().setMovementDirection(Vector3.right);
		enemy4.GetComponent<ZombieBehaviour>().Spawn();

		queueLeft.Enqueue(enemy4);
	}

	public GameObject getFirstEnemyLeft()
	{
		return queueLeft.Peek();
	}

	public GameObject getFirstEnemyRight()
	{
		return queueRight.Peek();
	}
}
