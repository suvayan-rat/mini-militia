using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerCount;
    [SerializeField] private TMP_Text playerID;


    private void Start()
    {
        //playerID.text = "View ID : " + PlayerController.instance.photonView.ViewID.ToString();
    }

    void Update()
    {
        playerCount.text = "Player : " + PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }
}
