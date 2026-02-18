using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;

public class JukeBox : MonoBehaviour, IInteractable
{
    [SerializeField] private Speaker _speaker;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _speaker.enabled = false;
    }
    public bool Interact(Interactor interactor)
    {
        GetComponent<PhotonView>().RPC("InteractWithJukeBox", RpcTarget.AllBufferedViaServer);
        return true;
    }


    [PunRPC]
    public void InteractWithJukeBox()
    {
        if(_speaker.enabled == false)
        {
            _speaker.enabled = true;
        }
        _speaker.enabled = false;
    }
}
