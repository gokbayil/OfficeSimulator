using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerNicknameManager : MonoBehaviour
{

    [SerializeField] InputField _nicknameInput;

    public void OnNicknameChange()
    {
        PhotonNetwork.NickName = _nicknameInput.text;
    }
}
