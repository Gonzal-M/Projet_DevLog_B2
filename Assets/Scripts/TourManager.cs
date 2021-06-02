using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class TourManager : MonoBehaviourPun
{
    public PhotonView photonView;  //instancie photon, permettra l'envoie et la réception de données d'une machine à l'autre

    string isHGtaken;   //Enregistre le nom du symbole dans la case donnée (ici, HG = Haut Gauche)
    string isHMtaken;   //Si la case donnée n'a pas été cliquée, elle est vide et n'a pas stocké de nom
    string isHDtaken;   //Donc : 
    string isMGtaken;   //Si une de ces variables a une valeur "croix", alors elle est déjà remplie, et elle est remplie par Joueur X
    string isMMtaken;   //Si une de ces variables a une valeur "cercle", alors elle est déjà remplie, et elle est remplie par Joueur O
    string isMDtaken;   //Si une de ces variables a une valeur null, alors la case est vide et donc disponible/cliquable
    string isBGtaken;
    string isBMtaken;
    string isBDtaken;

    public Sprite croix;
    public Sprite cercle;

    bool AQuiLeTour = true;     //true = tour du joueur O, false = tour du joueur X

    bool finTour;
    bool finJeu;

    public GameObject PartieFinie;
    Text gagnant;
    public GameObject CasePriseText;
    public TextMeshProUGUI TourDeQui;

    // Start is called before the first frame update
    void Start()
    {
        photonView = PhotonView.Get(this);
        gagnant = PartieFinie.transform.Find("Image/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!finJeu){    //tant que la partie n'est pas finie...
            if(CheckWin("croix")){  //...vérifie si le joueur X a gagné...
                finJeu = true;      //...si oui, la partie est finie,...
                PartieFinie.SetActive(true);    //...un nouvel écran s'affiche...
                gagnant.text = "Joueur X a gagné !";    //...et affiche que le joueur X a gagné
            }
            else if(CheckWin("cercle")){    //...vérifie si le joueur O a gagné et fait la même chose qu'avec X
                finJeu = true;
                PartieFinie.SetActive(true);
                gagnant.text = "Joueur O a gagné !";
            //Si personne n'a gagné mais que toutes les cases sont prises, alors il y a égalité
            }else if(isHGtaken != null && isHMtaken != null && isHDtaken != null && isMGtaken != null && isMMtaken != null && isMDtaken != null && isBGtaken != null && isBMtaken != null && isBDtaken != null){
                finJeu = true;
                PartieFinie.SetActive(true);
                gagnant.text = "Egalité !";
            }
        }
        
    }

    [PunRPC]
    public void CheckCase(string nomBouton){
        string symbole = "";
        if(!finTour){   //Si c'est le tour du joueur       
            switch(nomBouton){ //Selon le nom de la case (qui correspond à sa position)
                case "HG":  //Haut Gauche
                    if(isHGtaken == null){ //Si la case n'est pas prise
                        symbole = PlaceImage(nomBouton);   //Place la croix à l'endroit sélectionné
                        isHGtaken = symbole;   //Indique que la case est maintenant prise
                    }else{          //Si la case est prise
                        StartCoroutine(ShowCasePriseText());    //L'indique au joueur avec un message
                    }
                    break;
                case "HM":  //Haut Milieu 
                    if(isHMtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isHMtaken = symbole;
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "HD":  //Haut Droite
                    if(isHDtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isHDtaken = symbole;
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "MG":  //Milieu Gauche
                    if(isMGtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isMGtaken = symbole;
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "MM":  //Milieu Milieu 
                    if(isMMtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isMMtaken = symbole;
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "MD":  //Milieu Droite
                    if(isMDtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isMDtaken = symbole;   
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "BG":  //Bas Gauche
                    if(isBGtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isBGtaken = symbole;  
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "BM":  //Bas Milieu
                    if(isBMtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isBMtaken = symbole; 
                    }else{
                        StartCoroutine(ShowCasePriseText());;
                    }
                    break;
                case "BD":  //Bas Droite
                    if(isBDtaken == null){
                        symbole = PlaceImage(nomBouton);
                        isBDtaken = symbole;
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

    string PlaceImage(string nomBouton){
        GameObject buttonClicked = GameObject.Find(nomBouton);
        if(AQuiLeTour){
            buttonClicked.GetComponent<ClicCase>().ChangeImage(cercle);
            TourDeQui.SetText("Tour du Joueur X");  //Affiche qu'il s'agit maintenant du tour du Joueur X
            //finTour = true; //Indique que le tour du joueur actuel est terminé
            AQuiLeTour = !AQuiLeTour;   //Change de tour
            return "cercle";    //renvoie la valeur à enregistrer dans la variable is[NomDeCase]taken
        }else{
            buttonClicked.GetComponent<ClicCase>().ChangeImage(croix);
            TourDeQui.SetText("Tour du Joueur O");  //Affiche qu'il s'agit maintenant du tour du Joueur O
            //finTour = true;
            AQuiLeTour = !AQuiLeTour;
            return "croix";
        }  
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
