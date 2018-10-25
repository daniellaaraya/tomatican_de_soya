using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour {

	public InputField nameField;
	public InputField passwordField;

	public Button submitButton;

	public void CallLogin()
	{
		StartCoroutine(LogUser());
	}

	IEnumerator LogUser()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", nameField.text);
		form.AddField("password", passwordField.text);

		WWW www = new WWW("https://daniellaaraya.cl/tomatican/login.php", form);
		yield return www;
		if(www.text[0] == '0')
		{
			DBManager.username = nameField.text; //no es necesario traer el nombre desde la BD ya que es el mismo que se escribió si la validacón fue exitosa
			//DBManager.level = int.Parse(www.text.Split('\t')[1]);
			SceneManager.LoadScene("Play");

		}else
		{
			Debug.Log("User login failed. Error #" + www.text);
		}


	}
	public void VerifyInputs() // para validaciones de campos
	{
		submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);

	}
	

}
