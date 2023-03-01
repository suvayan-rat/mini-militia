using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;


public class PlayerMovement : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private float force;
    private Rigidbody2D rb;
    private PhotonView photonView;
    private float x, y;
    SpriteRenderer sr;
    private Vector2 dir;
    public bool isFlip;
    public PlayerHealth playerHealth;
  



    public void Start()
    {
        photonView = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        isFlip = false;
    }
   
    private void FixedUpdate()
    {
        if (photonView.IsMine)
            Move();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y = -1;
        }
        else
        {
            y = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
            sr.flipX = isFlip;
            isFlip = true;
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 1;
            sr.flipX = isFlip;
            isFlip = false;
        }
        else
        {
            x = 0;
        }

        dir = new Vector2(x, y);
        this.rb.AddForce(dir * force);
        this.photonView.RPC("PlayerPosition", RpcTarget.Others, dir);
    }

    [PunRPC]
    void PlayerPosition(Vector2 vector)
    {
        this.rb.AddForce(vector * force);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isFlip);
        }
        else
        {
            isFlip = (bool)stream.ReceiveNext();
            sr.flipX = isFlip;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet") && photonView.IsMine)
        {
            playerHealth.TakeDamage(20);
        }
    }
}

