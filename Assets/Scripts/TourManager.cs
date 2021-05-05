using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TourManager : MonoBehaviour
{
    string isHGtaken;
    string isHMtaken;
    string isHDtaken;
    string isMGtaken;
    string isMMtaken;
    string isMDtaken;
    string isBGtaken;
    string isBMtaken;
    string isBDtaken;

    GameObject buttonClicked;

    public Sprite croix;
    public Sprite cercle;

    bool finTour;
    public bool finJeu;

    public GameObject PartieFinie;
    Text gagnant;
    public GameObject CasePriseText;
    public TextMeshProUGUI TourDeQui;

    // Start is called before the first frame update
    void Start()
    {
        gagnant = PartieFinie.transform.Find("Image/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!finJeu){
            if(CheckWin("croix")){
                finJeu = true;
                PartieFinie.SetActive(true);
                gagnant.text = "Joueur X a gagné !"; 
            }
            else if(CheckWin("cercle")){
                finJeu = true;
                PartieFinie.SetActive(true);
                gagnant.text = "Joueur O a gagné !";
            }
        }
        
    }

    public void CheckCase(string nomBouton){
        if(!finTour){   //Si c'est le tour du joueur  
            buttonClicked = GameObject.Find(nomBouton);
            switch(buttonClicked.name){ //Selon le nom de la case (qui correspond à sa position)
                case "HG":  //Haut Gauche
                    if(isHGtaken == null){ //Si la case n'est pas prise
                        PlaceCroix(buttonClicked);   //Place la croix à l'endroit sélectionné
                        isHGtaken = "croix";   //Indique que la case est maintenant prise
                    }else{          //Si la case est prise
                        StartCoroutine(ShowCasePriseText());    //L'indique au joueur avec un message
                    }
                    break;
                case "HM":  //Haut Milieu 
                    if(isHMtaken == null){
                        PlaceCroix(buttonClicked);
                        isHMtaken = "croix";
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "HD":  //Haut Droite
                    if(isHDtaken == null){
                        PlaceCroix(buttonClicked);
                        isHDtaken = "croix";
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "MG":  //Milieu Gauche
                    if(isMGtaken == null){
                        PlaceCroix(buttonClicked);
                        isMGtaken = "croix";
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "MM":  //Milieu Milieu 
                    if(isMMtaken == null){
                        PlaceCroix(buttonClicked);
                        isMMtaken = "croix";
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "MD":  //Milieu Droite
                    if(isMDtaken == null){
                        PlaceCroix(buttonClicked);
                        isMDtaken = "croix";   
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "BG":  //Bas Gauche
                    if(isBGtaken == null){
                        PlaceCroix(buttonClicked);
                        isBGtaken = "croix";  
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "BM":  //Bas Milieu
                    if(isBMtaken == null){
                        PlaceCroix(buttonClicked);
                        isBMtaken = "croix"; 
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "BD":  //Bas Droite
                    if(isBDtaken == null){
                        PlaceCroix(buttonClicked);
                        isBDtaken = "croix";
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
            }
        }

    }

    IEnumerator ShowCasePriseText(){
        CasePriseText.SetActive(true);  //Affiche le texte
        yield return new WaitForSeconds(2); //Attend 2 secondes
        CasePriseText.SetActive(false); //Désactive le texte
    }
    void PlaceCroix(GameObject buttonClicked){
        buttonClicked.GetComponent<ClicCase>().ChangeImage(croix);  //Affiche une croix à l'emplacement choisi
        //finTour = true; //Indique que le tour du joueur est terminé
        TourDeQui.SetText("Tour de l'Adversaire");  //Affiche qu'il s'agit maintenant du tour de l'adversaire
    }

    bool CheckWin(string symbole){
        //Condition if qui vérifie toutes les combinaisons gagnantes possibles pour le joueur donné
        if((isHGtaken == symbole && isHMtaken == symbole && isHDtaken == symbole) ||    //ligne du haut
        (isMGtaken == symbole && isMMtaken == symbole && isMDtaken == symbole) ||       //ligne du milieu
        (isBGtaken == symbole && isBMtaken == symbole && isBDtaken == symbole) ||       //ligne du bas
        (isHGtaken == symbole && isMGtaken == symbole && isBGtaken == symbole) ||       //colonne de gauche
        (isHMtaken == symbole && isMMtaken == symbole && isBMtaken == symbole) ||       //colonne du milieu
        (isHDtaken == symbole && isMDtaken == symbole && isBDtaken == symbole) ||       //colonne de droite
        (isHGtaken == symbole && isMMtaken == symbole && isBDtaken == symbole) ||       //diagonale \ 
        (isHDtaken == symbole && isMMtaken == symbole && isBGtaken == symbole)){        //diagonale / 
            return true;
        }
        return false;
    }
}
