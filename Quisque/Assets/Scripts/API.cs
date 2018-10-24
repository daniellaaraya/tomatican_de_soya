using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class API : MonoBehaviour {

	public InputField nameField;
	public InputField passwordField;

	public Button submitButton;


	public void callRegister()
	{
		StartCoroutine(Register());
	}

	IEnumerator Register()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", nameField.text);
		form.AddField("password", passwordField.text);

		WWW www = new WWW("http://daniellaaraya.cl/Tomatica_de_soya/connection.php", form);
		yield return www;
		if(www.text == "0")
		{
			Debug.Log("User Created Succesfully");
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}else
		{
			Debug.Log("User Creation failed" + www.text);
		}

	}
	public void VerifyInputs() // para validaciones de campos
	{
		submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);

	}



}
