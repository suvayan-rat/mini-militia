using Photon.Pun;
using UnityEngine;

public class BulletSpawn : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunPos;
    private PhotonView photonView; 
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Space))
        {
            this.photonView.RPC("SpawnBullet", RpcTarget.All);
        }
    }

    [PunRPC]
    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPos.position, Quaternion.identity);
        bullet.GetComponent<BulletMovement>().isLeft = playerMovement.isFlip;
    }
}
