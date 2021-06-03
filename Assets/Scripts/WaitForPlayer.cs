using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForPlayer : MonoBehaviour
{

    public GameObject[] players;

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("player");
        if (players.Length >= 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
