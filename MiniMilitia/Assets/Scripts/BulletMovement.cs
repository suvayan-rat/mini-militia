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

        if (transform.position.x > 10f || transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

   

}
