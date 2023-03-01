using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private SpikeTrigger firstSpikeTrigger;
	[SerializeField] private SpikeTrigger secondSpikeTrigger;

	private void Awake()
	{
		Vector3 firstSpikeSpawnPosition = new Vector3(firstSpikeTrigger.gameObject.transform.position.x,
			firstSpikeTrigger.gameObject.transform.position.y + .1f,
			firstSpikeTrigger.gameObject.transform.position.z);

		firstSpikeTrigger.SetSpikeSpawnPosition(firstSpikeSpawnPosition);
	}

	private void Update()
	{
		if (firstSpikeTrigger != null && firstSpikeTrigger.GetActivatedFlag() == true && secondSpikeTrigger.gameObject.activeInHierarchy == false)
			SetUpSecondTrigger();
		if(secondSpikeTrigger != null && secondSpikeTrigger.GetActivatedFlag() == true)
		{
			firstSpikeTrigger.gameObject.SetActive(false);
			secondSpikeTrigger.gameObject.SetActive(false);
		}
	}
	private void SetUpSecondTrigger()
	{
		Vector3 secondSpikeSpawnPosition = new Vector3(secondSpikeTrigger.gameObject.transform.position.x,
			secondSpikeTrigger.gameObject.transform.position.y + .1f,
			secondSpikeTrigger.gameObject.transform.position.z);

		secondSpikeTrigger.SetSpikeSpawnPosition(secondSpikeSpawnPosition);

		secondSpikeTrigger.SetSpawnTimer(1);

		secondSpikeTrigger.gameObject.SetActive(true);
	}
}