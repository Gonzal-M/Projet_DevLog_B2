using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public string pseudo;
    public TMP_InputField inputText;

    public GameObject LoginCanvas;
    public GameObject WaitCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserLogIn(){
        pseudo = inputText.text;
        LoginCanvas.SetActive(false);
        WaitCanvas.SetActive(true);
    }
}
