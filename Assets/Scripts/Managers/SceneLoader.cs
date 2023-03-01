using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
	public enum Scene
	{
		Level2,
		LevelX,
		LevelX3D
	};
    public static void Load(Scene scene)
	{
		SceneManager.LoadScene(scene.ToString());
	}
}
