using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SlideShow : MonoBehaviourPunCallbacks
{
    public Material[] material;
    private Renderer renderer;
    private int pageCounter = 0;


    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
           GetComponent<PhotonView>().RPC("ForwardSlide",RpcTarget.AllBufferedViaServer);

        if (Input.GetKeyDown(KeyCode.K))
            GetComponent<PhotonView>().RPC("BackwardSlide", RpcTarget.AllBufferedViaServer);
    }


    [PunRPC] 
    public void ForwardSlide()
    {
        
        if (pageCounter == material.Length)
        {
            renderer.material = material[0];
            pageCounter = 0;
        }
        else
        {
            pageCounter++;
            renderer.material = material[pageCounter];
        }
    }

    [PunRPC]
    public void BackwardSlide()
    {
        if(pageCounter == 0)
        {
            pageCounter = material.Length;
            renderer.material = material[pageCounter];
        }
        else
        {
            pageCounter--;
            renderer.material = material[pageCounter];
        }
    }

    
}
