using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNextLevel3D : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "PlayerVisual")
		{
			Debug.Log("Hey");
			SceneLoader.Load(SceneLoader.Scene.Level8);
		}
	}
}
