using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
	[SerializeField] private SceneLoader.Scene scene;
	public void RestartLevel()
	{
		SceneLoader.Load(scene);
	}
}
