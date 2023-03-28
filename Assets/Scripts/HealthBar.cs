using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	private HealthManager healthManager;

    public void Setup(HealthManager healthManager)
	{
		this.healthManager = healthManager;
	}
	private void Update()
	{
		//Debug.Log(healthManager.GetHealth());
		transform.Find("Bar").localScale = new Vector3(healthManager.GetHealthPercent(), 1);	
		if(healthManager.GetHealthPercent() == 0)
			this.gameObject.SetActive(false);
	}

	public HealthManager getHealthManagerPlayer()
	{
		return healthManager;
	}
}
