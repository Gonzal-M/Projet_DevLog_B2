using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicCase : MonoBehaviour
{
    TourManager tourManager;
    // Start is called before the first frame update
    void Start()
    {
        tourManager = GameObject.Find("GameManager").GetComponent<TourManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoixCase(){
        Debug.Log("clic");
        tourManager.CheckCase(gameObject.name);
    }
}
