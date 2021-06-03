using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Login : MonoBehaviour
{
    public string pseudo;
    public TMP_InputField nameField;

    public GameObject LoginCanvas;
    public GameObject WaitCanvas;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("hours", System.DateTime.Now.Hour);
        form.AddField("minutes", System.DateTime.Now.Minute);
        form.AddField("secondes", System.DateTime.Now.Second);

        WWW www = new WWW("http://localhost/php/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
            DBManager.username = nameField.text;
            //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            UserLogIn();
        }
        else
        {
            Debug.Log("User creation failed. Error#" + www.text);
        }
    }

    public void UserLogIn(){
        LoginCanvas.SetActive(false);
        WaitCanvas.SetActive(true);
        PhotonNetwork.Instantiate("player", Vector3.zero, Quaternion.identity);
    }
}
