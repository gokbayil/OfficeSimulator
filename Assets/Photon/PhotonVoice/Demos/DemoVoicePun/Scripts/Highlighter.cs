// ----------------------------------------------------------------------------
// <copyright file="Highlighter.cs" company="Exit Games GmbH">
// Photon Voice Demo for PUN- Copyright (C) 2016 Exit Games GmbH
// </copyright>
// <summary>
// Class that highlights the Photon Voice features by toggling isometric view 
// icons for the two components Recorder and Speaker.
// </summary>
// <author>developer@photonengine.com</author>
// ----------------------------------------------------------------------------

#pragma warning disable 0649 // Field is never assigned to, and will always have its default value

namespace ExitGames.Demos.DemoPunVoice
{

    using UnityEngine;
    using UnityEngine.UI;
	using Photon.Voice.Unity;
	using Photon.Voice.PUN;

    [RequireComponent(typeof(Canvas))]
    public class Highlighter : MonoBehaviour
    {
        private Canvas canvas;

        private PhotonVoiceView photonVoiceView;

        [SerializeField]
        private Image recorderSprite;

        [SerializeField] private GameObject _speaker;

        private bool _speakerIsOff = false;

        //[SerializeField]
        //private Image speakerSprite;


        private void OnEnable()
        {
            ChangePOV.CameraChanged += this.ChangePOV_CameraChanged;
        }

        private void OnDisable()
        {
            ChangePOV.CameraChanged -= this.ChangePOV_CameraChanged;
        }


        private void ChangePOV_CameraChanged(Camera camera)
        {
            this.canvas.worldCamera = camera;
        }

        private void Awake()
        {
            this.canvas = this.GetComponent<Canvas>();
            if (this.canvas != null && this.canvas.worldCamera == null) { this.canvas.worldCamera = Camera.main; }
            this.photonVoiceView = this.GetComponentInParent<PhotonVoiceView>();
        }


        // Update is called once per frame
        private void Update()
        {
            if (_speakerIsOff)
            {
                this.recorderSprite.enabled = false;
            }
            else
            {
                this.recorderSprite.enabled = this.photonVoiceView.IsRecording;
            }
            
            //this.speakerSprite.enabled = this.photonVoiceView.IsSpeaking;
        }

        private void LateUpdate()
        {
            if (this.canvas == null || this.canvas.worldCamera == null) { return; } // should not happen, throw error
            this.transform.rotation = Quaternion.Euler(0f, this.canvas.worldCamera.transform.eulerAngles.y, 0f); //canvas.worldCamera.transform.rotation;
        }

        private void CheckForSpeaker()
        {
            if (_speaker.GetComponent<AudioSource>().enabled && _speaker.GetComponent<Speaker>().enabled)
            {
                _speakerIsOff = false;
            }
            else
            {
                _speakerIsOff = true;
            }
        }
    }
}