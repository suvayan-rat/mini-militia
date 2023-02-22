using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkConnect : MonoBehaviour
{
    public GameObject player;
    void OnEnable()
    {
        PhotonNetwork.Instantiate(player.name, Vector2.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
