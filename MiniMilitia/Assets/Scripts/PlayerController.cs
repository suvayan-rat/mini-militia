using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float force;
    Rigidbody2D rb;
    PhotonView photonView;

    bool playerIsMovingUp;
    bool playerIsMovingDown;
    bool playerIsMovingRight;
    bool playerIsMovingLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Move();
            Movement();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerIsMovingUp = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerIsMovingDown = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerIsMovingLeft = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerIsMovingRight = true;
        }
    }
    void Movement()
    {
        if (playerIsMovingUp)
        {
            rb.AddForce(Vector2.up * force * Time.deltaTime);
        }
        if (playerIsMovingDown)
        {
            rb.AddForce(Vector2.down * force * Time.deltaTime);
        }
        if (playerIsMovingLeft)
        {
            rb.AddForce(Vector2.left * force * Time.deltaTime);
        }
        if (playerIsMovingRight)
        {
            rb.AddForce(Vector2.right * force * Time.deltaTime);
        }
    }
}

