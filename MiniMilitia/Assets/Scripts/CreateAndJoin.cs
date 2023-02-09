using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{

    [SerializeField] private TMP_InputField createRoomName;
    [SerializeField] private TMP_InputField joinRoomName;


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomName.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Gameplay");
    }
}
