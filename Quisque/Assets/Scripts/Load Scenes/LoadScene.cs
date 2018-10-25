using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
	public void LoadRegisterMenu()
	{
		SceneManager.LoadScene("RegisterMenu");

	}
	public void LoadLoginMenu()
	{
		SceneManager.LoadScene("LoginMenu");

	}
	public void LoadLogOptionsMenu()
	{
		SceneManager.LoadScene("LogOptions");

	}

}