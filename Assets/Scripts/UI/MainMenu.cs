using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
	{
		SceneLoader.Load(SceneLoader.Scene.Level1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
