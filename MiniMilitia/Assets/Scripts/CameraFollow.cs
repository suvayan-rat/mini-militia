using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (PhotonView.Get(player).IsMine)
            {
                this.target = player.transform;
                break;
            }
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
