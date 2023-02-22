using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
	[SerializeField] private GameObject spikePrefab;
	private GameObject spikeInstance;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Vector3 instantiationPosition = new Vector3(transform.position.x,
			transform.position.y + .8f,
			transform.position.z);
		spikeInstance = Instantiate(spikePrefab, instantiationPosition, Quaternion.identity);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Animator animator = spikeInstance.GetComponent<Animator>();

		animator.SetBool("LeftArea", true);

		Destroy(spikeInstance, .25f);

	}
}
