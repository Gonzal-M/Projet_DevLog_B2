using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TourManager : MonoBehaviour
{
    bool isHGtaken;
    bool isHMtaken;
    bool isHDtaken;
    bool isMGtaken;
    bool isMMtaken;
    bool isMDtaken;
    bool isBGtaken;
    bool isBMtaken;
    bool isBDtaken;

    public GameObject prefabCroix;

    bool finTour;

    public GameObject CasePriseText;
    public TextMeshProUGUI TourDeQui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoixCase(){
        if(!finTour){   //Si c'est le tour du joueur
            Debug.Log("boop");
            GameObject buttonClicked = EventSystem.current.currentSelectedGameObject; //Récupère la case sur laquelle le joueur a cliqué
            switch(buttonClicked.name){ //Selon le nom de la case (qui correspond à sa position)
                case "HG":  //Haut Gauche
                    if(!isHGtaken){ //Si la case n'est pas prise
                        PlaceCroix(buttonClicked);   //Place la croix à l'endroit sélectionné
                        isHGtaken = true;   //Indique que la case est maintenant prise
                    }else{          //Si la case est prise
                        ShowCasePriseText();    //L'indique au joueur avec un message
                    }
                    break;
                case "HM":  //Haut Milieu 
                    if(!isHMtaken){
                        PlaceCroix(buttonClicked);
                        isHMtaken = true;
                    }else{
                        ShowCasePriseText();
                    }
                    break;
                case "HD":  //Haut Droite
                    if(!isHDtaken){
                        PlaceCroix(buttonClicked);
                        isHDtaken = true;
                    }else{
                        ShowCasePriseText();
                    }
                    break;
                case "MG":  //Milieu Gauche
                    if(!isMGtaken){
                        PlaceCroix(buttonClicked);
                        isMGtaken = true;
                    }else{
                        ShowCasePriseText();
                    }
                    break;
                case "MM":  //Milieu Milieu 
                    if(!isMMtaken){
                        PlaceCroix(buttonClicked);
                        isMMtaken = true;
                    }else{
                        ShowCasePriseText();
                    }
                    break;
                case "MD":  //Milieu Droite
                    if(!isMDtaken){
                        PlaceCroix(buttonClicked);
                        isMDtaken = true;   
                    }else{
                        ShowCasePriseText();
                    }
                    break;
                case "BG":  //Bas Gauche
                    if(!isBGtaken){
                        PlaceCroix(buttonClicked);
                        isBGtaken = true;  
                    }else{
                        ShowCasePriseText();
                    }
                    break;
                case "BM":  //Bas Milieu
                    if(!isBMtaken){
                        PlaceCroix(buttonClicked);
                        isBMtaken = true; 
                    }else{
                        ShowCasePriseText();
                    }
                    break;
                case "BD":  //Bas Droite
                    if(!isBDtaken){
                        PlaceCroix(buttonClicked);
                        isBDtaken = true;
                    }else{
                        ShowCasePriseText();
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
        Instantiate(prefabCroix, buttonClicked.transform.position, buttonClicked.transform.rotation);   //Fait apparaitre la croix à la position de la case choisie
        finTour = true; //Indique que le tour du joueur est terminé
        TourDeQui.SetText("Tour de l'Adversaire");  //Affiche qu'il s'agit maintenant du tour de l'adversaire
    }
}
