using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraChange : MonoBehaviour
{
    public GameObject TPCam;
    public GameObject FPCam;
    private int CamMode;

    private void Start()
    {
        if (!GetComponent<PhotonView>().IsMine)
        {
            Destroy(TPCam);
            Destroy(FPCam);
        }
    }
    void Update()
    {
        CameraChanger();
    }

    private void CameraChanger()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CamMode == 0)
            {
                CamMode = 1;
            }
            else
            {
                CamMode = 0;
            }
            StartCoroutine(CameraChange());
        }

        IEnumerator CameraChange()
        {
            yield return new WaitForSeconds(0.01f);
            if (CamMode == 0)
            {
                TPCam.SetActive(true);
                FPCam.SetActive(false);
            }
            if (CamMode == 1)
            {
                FPCam.SetActive(true);
                TPCam.SetActive(false);
            }
        }
    }
}
