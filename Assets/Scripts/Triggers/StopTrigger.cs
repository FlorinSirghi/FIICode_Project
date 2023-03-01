using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    [SerializeField] private GameObject trampolineTrigger;
    [SerializeField] private GameObject levelManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.name == "Player")
		{
			trampolineTrigger.GetComponent<SecondTrampolineTrigger>().setActivatedFlag(false);
			levelManager.GetComponent<LevelManager3>().setRevealLevelFlag(true);
		}
	}
}
