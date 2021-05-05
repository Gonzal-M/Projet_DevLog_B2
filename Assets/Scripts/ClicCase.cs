using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        tourManager.CheckCase(gameObject.name);
    }

    public void ChangeImage(Sprite symbole){
        image.enabled = true;
        image.sprite = symbole;
    }
}
