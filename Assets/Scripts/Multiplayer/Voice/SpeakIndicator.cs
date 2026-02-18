using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice;
using Photon.Pun;
using Photon.Voice.PUN;
using UnityEngine.UI;
using Photon.Voice.Unity;
using System.Reflection;

public class SpeakIndicator : MonoBehaviour
{
    private PhotonVoiceView _playerPVV;
    [SerializeField] private GameObject _speakerIndicator;
    private PhotonView _view;

    private void Start()
    {
        _speakerIndicator.SetActive(false);
        Debug.Log("logx Start Log");
        _view = GetComponent<PhotonView>();
        _playerPVV = GetComponent<PhotonVoiceView>();
    }

    private void Update()
    {
        if (_playerPVV.IsSpeaking)
            _speakerIndicator.SetActive(true);

        else
            _speakerIndicator.SetActive(false);
        //_speakerIndicator2.SetActive(_playerPVV.IsRecording);
        /*Debug.Log("logx 1");
        /*
        if (_playerPVV.IsRecording )
        {
           // _speakerIndicator.SetActive(true);
            Debug.Log("logx 2" + " " + PhotonNetwork.NickName);
        }
        if (_playerPVV.IsSpeaking)
        {
            // _speakerIndicator.SetActive(true);
            Debug.Log("logx 3" + " " + PhotonNetwork.NickName);
        }
        */
        /*
        if (_playerPVV.IsRecording && !_playerPVV.IsSpeaking)
        {
            _speakerIndicator.SetActive(true);
            Debug.Log("logx 2" + " " + PhotonNetwork.NickName);
        }
        else if (!_playerPVV.IsRecording && _playerPVV.IsSpeaking)
            {
                _speakerIndicator.SetActive(true);
                Debug.Log("logx 2.1" + " " + PhotonNetwork.NickName);
            }

        else
        {
            Debug.Log("logx 3" + " " + PhotonNetwork.NickName);
            if (!_playerPVV.IsSpeaking)
            {
                _speakerIndicator.SetActive(false);
                Debug.Log("logx 4" + " " + PhotonNetwork.NickName);
            }
            
        }
        
        Debug.Log("logx end " + PhotonNetwork.NickName);*/
    }

}
