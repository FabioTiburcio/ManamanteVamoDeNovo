using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	public GameObject tutorial;

	public void Start()
	{
		PlayerPrefs.SetInt("hasPlayed", 0);
	}
	public void Exit()
	{
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
	#else
      Application.Quit();
	#endif
	}

	public void ChangeScene()
	{
		SceneManager.LoadScene(1);
		
	}

	public void StartGame()
	{
		if(PlayerPrefs.GetInt("hasPlayed") == 0)
		{
			tutorial.SetActive(true);
		} else
		{
			PlayerPrefs.SetInt("hasPlayed", 1);
			ChangeScene();
		}
	}

}