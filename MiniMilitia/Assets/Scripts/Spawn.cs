using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviourPunCallbacks, IPunObservable
{
     public GameObject playerPrefab;
    private GameObject player;
    // PhotonView photonView;
    // void Start()
    // {
    //     Test();
    //     this.photonView = GetComponent<PhotonView>();
    //     Debug.LogError("Start");
    //     this.photonView.RPC("Spawnner", RpcTarget.All);

    //     //if (photonView.IsMine)
    //     //{
    //     //    Debug.LogError("ismine");
    //     //}
    // }

    //[PunRPC]
    //void Spawnner()
    // {
    //     Debug.LogError("Spawn");
    //     Instantiate(playerPrefab, transform.position, transform.rotation);
    // }

    private void Start()
    {
        player = Instantiate(playerPrefab);
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(player);
        }
        else
        {
            player = (GameObject) stream.ReceiveNext();
        }
    }








    void Test()
    {
        
    }
}
