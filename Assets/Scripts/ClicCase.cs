using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class ClicCase : MonoBehaviour
{
    TourManager tourManager;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        tourManager = GameObject.Find("GameManager").GetComponent<TourManager>();

        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChoixCase(){
        tourManager.photonView.RPC("CheckCase", RpcTarget.All, gameObject.name);    //quand le joueur clique sur une case, cette fonction renvoie le nom de la case choisie à la fonction du TourManager
    }

    public void ChangeImage(Sprite symbole){
        image.enabled = true;   //active l'image
        image.sprite = symbole; //met l'image du symbole donné (X ou O)
    }
}
