using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.UIElements;

using Button = UnityEngine.UI.Button;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public Canvas uiLoading;
    public Canvas uiLobby;

    public TMP_InputField createRoomName;
    public TMP_InputField joinRoomName;

    public Button creatRoom;
    public Button joinRoom;

    //public ScrollView roomList;
    void Start()
    {
        uiLoading.gameObject.SetActive(true);
        uiLobby.gameObject.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting...");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected");
        MasterConnected();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomName.text);
        Debug.Log("Room created and joined");
        //RoomOptions 
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
        // check if joined successfully
        Debug.Log("Room joined");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Gameplay");
    }
    void MasterConnected()
    {
        uiLoading.gameObject.SetActive(false);
        uiLobby.gameObject.SetActive(true);
    }
}
