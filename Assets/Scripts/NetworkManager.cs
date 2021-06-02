using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("connecting ...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connectertomaster");
        base.OnConnectedToMaster();

        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 10;
        roomOption.IsVisible = true;
        roomOption.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOption, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
