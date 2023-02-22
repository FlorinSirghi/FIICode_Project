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
		if (firstSpikeTrigger.getActivatedFlag() == true && secondSpikeTrigger.gameObject.activeInHierarchy == false)
			SetUpSecondTrigger();
	}
	private void SetUpSecondTrigger()
	{
		Vector3 secondSpikeSpawnPosition = new Vector3(secondSpikeTrigger.gameObject.transform.position.x,
			secondSpikeTrigger.gameObject.transform.position.y + .8f,
			secondSpikeTrigger.gameObject.transform.position.z);

		secondSpikeTrigger.SetSpikeSpawnPosition(secondSpikeSpawnPosition);

		secondSpikeTrigger.gameObject.SetActive(true);
	}
}
