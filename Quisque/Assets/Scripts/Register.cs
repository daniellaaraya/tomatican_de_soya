using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Register : MonoBehaviour {

	public InputField nameField;
	public InputField passwordField;
	public Button submitButton;
	public GameObject panelMessage;
	public Text messageTest;

	public void callRegister()
	{
		StartCoroutine(RegisterUser());
	}

	IEnumerator RegisterUser()
	{
		if(ValidatePassword(passwordField.text) == true)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", nameField.text);
			form.AddField("password", passwordField.text);
			
			WWW www = new WWW("https://daniellaaraya.cl/tomatican/connection.php", form);
			yield return www;
			if(www.text == "0")
			{
				Debug.Log("User Created Succesfully");
				SceneManager.LoadScene("Play");
			}else
			{
				Debug.Log("User Creation failed" + www.text);
				ShowMessage(www.text);
			
			}
		}

	}
	public void VerifyInputs() // para validaciones de campos
	{
		submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);


	}
	public void ShowMessage(string conMessage)
	{
		panelMessage.SetActive(true);
		messageTest.text = conMessage;
	}

	public bool ValidatePassword(string pass)
	{
		if(pass.Length < 5)
		{
			ShowMessage("La contraseña debe tener al menos 5 caracteres");
			return false;
		}
		if(pass.Contains(" "))
		{
			ShowMessage("La contraseña no puede contener espacios");
			return false;
		}
			

		return true;
	}

}
