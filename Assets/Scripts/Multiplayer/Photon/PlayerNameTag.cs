using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerNameTag : MonoBehaviourPun
{

    [SerializeField] Text nameText;


    private void Start()
    {
        nameText.text = photonView.Owner.NickName;
    }
    
}
