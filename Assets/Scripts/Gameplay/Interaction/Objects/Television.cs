using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Television : MonoBehaviour, IInteractable
{

    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    [PunRPC]
    public void InteractWithTV()
    {
        if (_renderer.enabled)
            _renderer.enabled = false;
        else
            _renderer.enabled = true;
    }
    

    public bool Interact(Interactor interactor)
    {
        GetComponent<PhotonView>().RPC("InteractWithTV", RpcTarget.AllBufferedViaServer);
        return true;
    }
    
}
