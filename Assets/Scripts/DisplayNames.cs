using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class DisplayNames : MonoBehaviour
{

    public TextMeshProUGUI joueur1;
    public TextMeshProUGUI joueur2;

    PhotonView photonView;

    private void Start()
    {

        photonView = PhotonView.Get(this);

        joueur1.SetText(DBManager.username);

        photonView.RPC("NameTheSecondPlayer", RpcTarget.Others, DBManager.username);

    }

    [PunRPC]
    public void NameTheSecondPlayer(string name)
    {
        joueur2.SetText(name);
    }





    /*
        void Start()
        {
            photonView = PhotonView.Get(this);

            string playername = DBManager.username;

            if (joueur1.text == "")
            {
                photonView.RPC("joueur1Display", RpcTarget.All, playername);
            }
            else
            {
                photonView.RPC("joueur1Display", RpcTarget.All, playername);
            }
        }

        [PunRPC]
        public void joueur1Display(string username)
        {
            joueur1.SetText(username);
        }

        [PunRPC]
        public void joueur2Display(string username)
        {
            joueur2.SetText(username);
        }*/


}