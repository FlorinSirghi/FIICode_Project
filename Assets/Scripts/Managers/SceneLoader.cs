using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
	public enum Scene
	{
		Level1,
		Level2,
		Level3,
		Level4,
		Level5,
		Level6,
		Level7,
		Level73D,
		Level8,
		Level9,
		EndGame
	};
    public static void Load(Scene scene)
	{
		SceneManager.LoadScene(scene.ToString());
	}
}
