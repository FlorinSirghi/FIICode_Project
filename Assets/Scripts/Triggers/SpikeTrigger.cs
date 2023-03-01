using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
	[SerializeField] private GameObject spikePrefab;
	private GameObject spikeInstance;

	private Vector3 spikeSpawnPosition;
	private Vector3 spikeSpawnRotation = Vector3.zero;
	private bool activated;
	private int spawnTime = 0;
	private int destroyTime = 2;

	private void Awake()
	{
		activated = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Invoke("SpawnSpike", spawnTime);

			Invoke("DestroySpike", destroyTime);

			activated = true;
		}
	}

	private void SpawnSpike()
	{
		spikeInstance = Instantiate(spikePrefab, spikeSpawnPosition, Quaternion.Euler(spikeSpawnRotation));
	}

	private void DestroySpike()
	{
		if (spikeInstance != null)
		{
			Animator animator = spikeInstance.GetComponent<Animator>();

			animator.SetBool("LeftArea", true);

			Destroy(spikeInstance, .15f);
		}
	}

	public void SetSpikeSpawnPosition(Vector3 spawnPosition)
	{
		spikeSpawnPosition = spawnPosition;
	}

	public Vector3 GetSpikeSpawnPosition()
	{
		return spikeSpawnPosition;
	}

	public bool GetActivatedFlag()
	{
		return activated;
	}

	public void SetSpikeSpawnRotation(Vector3 rotation)
	{
		spikeSpawnRotation = rotation;
	}

	public void SetSpawnTimer(int time)
	{
		spawnTime = time;
	}
}
