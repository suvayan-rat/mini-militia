using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletMovement : MonoBehaviourPunCallbacks
{
    [SerializeField] private float speed;
    public bool isLeft;
   

    void Update()
    {
        if(!isLeft)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (transform.position.x > 48 || transform.position.x < -48)
        {
            Destroy(this.gameObject);
        }
    }

   

}
