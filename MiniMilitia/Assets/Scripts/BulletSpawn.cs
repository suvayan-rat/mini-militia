using Photon.Pun;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunPos;
    private PhotonView photonView;
    //[SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Space))
        {
            photonView.RPC("SpawnBullet", RpcTarget.All);
        }
    }

    [PunRPC]
    void SpawnBullet()
    {
         Instantiate(bulletPrefab, gunPos.transform.position, gunPos.transform.rotation);
        //bullet.GetComponent<BulletMovement>().isLeft = playerMovement.isFlip;
    }
}
