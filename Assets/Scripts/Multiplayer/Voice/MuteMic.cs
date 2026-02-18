using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class MuteMic : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button muteButton;
    [SerializeField] private Text muteState;
    [SerializeField] private GameObject characterMic;
    private bool isMuted = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (PauseMenu.isPaused)
        {
            pauseMenu.SetActive(true);
            MicStateChanger();
        }
        else
            pauseMenu.SetActive(false);
    }

    public void MicStateChanger()
    {
        if (isMuted)
        {
            characterMic.SetActive(false);
            muteState.text = "Mikrofon Kapalý";
            isMuted = false;
        }
        else
        {
            muteState.text = "Mikrofon Açýk";
            characterMic.SetActive(true);
            isMuted = true;
        }
    }
}
