using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Camera Related Fields")]
    [SerializeField] private CameraController camControl;

    [Header("Interaction")]
    [SerializeField] private float interactionRange = 5.0f;
    [SerializeField] private LayerMask interactableLayers;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.startGameplay == true && GameManager._blackoutInEffect == false)
        {
            if (GameManager.pauseGame == false && PlayerInput.interact == true)
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        //Debug.Log("Attempting to interact");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, Camera.main.transform.TransformDirection(Vector3.forward) * interactionRange, Color.red, 3.0f);

        //if (Physics.Raycast(ray, out hit, interactionRange))
        //{
        //    Debug.Log("Hit something: " + hit.collider.name);
        //}

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayers, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Hit an interactible: " + hit.collider.name);

            DoorController dC = hit.collider.GetComponentInParent<DoorController>();
            PlayStareAnimation stare = hit.collider.GetComponent<PlayStareAnimation>();
            HallDoor hD = hit.collider.GetComponent<HallDoor>();

            if (dC != null)
            {
                dC.HandleDoorInteraction(hit.collider.gameObject.layer, hit.collider);
            }
            else if (stare != null)
            {
                stare.Stare();
            }
            else if (hD != null)
            {
                hD.OpenDoor();
            }
            else if (hit.collider.CompareTag("Key"))
            {
                DoorKnob._canOpenDoor = true;
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
