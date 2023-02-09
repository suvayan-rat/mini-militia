using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        PhotonNetwork.Instantiate(player.name, Vector2.zero, Quaternion.identity);
    }
}
