using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
	[SerializeField] private GameObject spikePrefab;
	private GameObject spikeInstance;

	private Vector3 spikeSpawnPosition;
	private bool activated;

	private void Awake()
	{
		activated = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		spikeInstance = Instantiate(spikePrefab, spikeSpawnPosition, Quaternion.identity);

		activated = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Animator animator = spikeInstance.GetComponent<Animator>();

		animator.SetBool("LeftArea", true);

		Destroy(spikeInstance, .15f);

	}

	public void SetSpikeSpawnPosition(Vector3 spawnPosition)
	{
		spikeSpawnPosition = spawnPosition;
	}

	public Vector3 GetSpikeSpawnPosition()
	{
		return spikeSpawnPosition;
	}

	public bool getActivatedFlag()
	{
		return activated;
	}
}
