using System.Collections;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviourPunCallbacks, IPunObservable
{
    public float health = 100;
    [SerializeField] private TMP_Text healthBar;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerMovement playerMovement;
    private bool isActive;

    private void Start()
    {
        isActive = true;
    }

    private void Update()
    {
        healthBar.text = health.ToString();
        spriteRenderer.enabled = isActive;
        playerMovement.enabled = isActive;
        this.healthBar.enabled = isActive;
    }

    public void OnPhotonSerializeView(PhotonStream photonStream, PhotonMessageInfo info)
    {
        if (photonStream.IsWriting)
        {
            photonStream.SendNext(health);
            photonStream.SendNext(isActive);
        }
        else
        {
            health = (float)photonStream.ReceiveNext();
            isActive = (bool)photonStream.ReceiveNext();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isActive = false;
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        isActive = true;
        health = 100;
    }

}
