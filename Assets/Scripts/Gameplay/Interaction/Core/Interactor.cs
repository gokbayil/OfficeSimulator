using Photon.Pun;
using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private Speaker _speaker;
    private bool isSpeakerActive = true;
    private PhotonView _view;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;


    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();

            if(interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact(this);
            }
        }

        if (Input.GetKeyDown(KeyCode.M) && _view.IsMine)
        {
            if (isSpeakerActive)
            {
                _speaker.GetComponent<AudioSource>().enabled = false;
                _speaker.GetComponent<Speaker>().enabled = false;
                //_speaker.SetActive(false);
                isSpeakerActive = false;
            }
            else
            {
                _speaker.GetComponent<AudioSource>().enabled = true;
                _speaker.GetComponent<Speaker>().enabled = true;
                isSpeakerActive = true;
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);

    }



}
