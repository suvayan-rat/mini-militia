using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class ChangeText : MonoBehaviour
{
    private SpriteRenderer mSpriteRenderer;
    [SerializeField] PhotonView view;
    void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Change();
            }
        }
    }

    void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }
    void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == 101)
        {
            object[] datas = (object[])obj.CustomData;
            float r = (float)datas[0];
            float g = (float)datas[1];
            float b = (float)datas[2];
            mSpriteRenderer.color = new Color(r, g, b, 1f);
        }
    }

    void Change()
    {
        float r, g, b;
        r = Random.Range(0f, 1f);
        g = Random.Range(0f, 1f);
        b = Random.Range(0f, 1f);
        mSpriteRenderer.color = new Color(r, g, b, 1f);

        object[] data = new object[] {r, g, b};

        PhotonNetwork.RaiseEvent(101, data, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }
}
