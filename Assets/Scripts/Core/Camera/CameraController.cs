using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
    public GameObject TPCam;
    public GameObject FPCam;
    public GameObject TPplayerCameraFollow;
    public GameObject FPplayerCameraFollow;
    bool isTPCam = true;
    private PhotonView view;



    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.C))
        {
            CamChanger();
        }
        
    }

    private void CamChanger()
    {
        if (view.IsMine)
        {
            if (isTPCam)
            {
                TPCam.SetActive(false);
                FPCam.SetActive(true);
                TPplayerCameraFollow.SetActive(false);
                FPplayerCameraFollow.SetActive(true);
            }
            else
            {
                TPCam.SetActive(true);
                FPCam.SetActive(false);
                TPplayerCameraFollow.SetActive(true);
                FPplayerCameraFollow.SetActive(false);
            }

            isTPCam = !isTPCam;
        }
    }
}
