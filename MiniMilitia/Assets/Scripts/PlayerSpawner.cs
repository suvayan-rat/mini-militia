using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public GameObject PlayerPrefab;
    public const byte CustomManualInstantiationEventCode = 1;

    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    private Transform random;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab);

        PhotonView photonView = player.GetComponent<PhotonView>();
        if (PhotonNetwork.AllocateViewID(photonView))
        {
            object[] data = new object[] { player.transform.position, player.transform.rotation, photonView.ViewID };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            PhotonNetwork.RaiseEvent(CustomManualInstantiationEventCode, data, raiseEventOptions, SendOptions.SendReliable);
        }
    }

    public void OnEvent(EventData eventData)
    {
        if (eventData.Code == CustomManualInstantiationEventCode)
        {
            Debug.Log(eventData.Code);
            object[] data = (object[])eventData.CustomData;

            GameObject player = Instantiate(PlayerPrefab);
            player.transform.position = (Vector3)data[0];
            player.transform.rotation = (Quaternion)data[1];

            PhotonView photonView = player.GetComponent<PhotonView>();
            photonView.ViewID = (int)data[2];
        }
    }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }


}
