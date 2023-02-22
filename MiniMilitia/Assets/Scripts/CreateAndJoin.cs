using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{

    [SerializeField] private TMP_InputField createRoomName;
    [SerializeField] private TMP_InputField joinRoomName;
    RoomOptions roomOptions;

   
    public void CreateRoom()
    {
        roomOptions = new RoomOptions() {IsVisible = true, MaxPlayers = 3 };
        PhotonNetwork.CreateRoom(createRoomName.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Gameplay");
    }
  
}
