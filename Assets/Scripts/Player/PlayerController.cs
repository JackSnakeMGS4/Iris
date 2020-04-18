using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Status { Idle, Walking, Interacting, Flying }
public class StatusEvent : UnityEvent<Status> { }
public class PlayerController : MonoBehaviour
{
    public StatusEvent onStatusChange;

    [SerializeField] private Status status;
    public Status moveStatus { get { return status; } }

    private CameraController cam;
    private PlayerInput pInput;
    private PlayerMovement pMove;

    private bool canInteract;

    void ChangeStatus(Status s)
    {
        if (status == s)
        {
            return;
        }

        status = s;

        if (onStatusChange != null)
        {
            onStatusChange.Invoke(status);
        }
    }

    public void AddStatusChange(UnityAction<Status> action)
    {
        if (onStatusChange == null)
        {
            onStatusChange = new StatusEvent();
        }

        onStatusChange.AddListener(action);
    }

    private void Start()
    {
        pInput = GetComponent<PlayerInput>();
        cam = GetComponentInChildren<CameraController>();
        pMove = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (GameManager.startGameplay == true && GameManager._blackoutInEffect == false)
        {
            UpdateMovement();
        }
    }

    private void UpdateMovement()
    {
        if ((int)status <= 1)
        {
            if (pInput.input.magnitude > 0.02f)
            {
                ChangeStatus(Status.Walking);
            }
            else
            {
                ChangeStatus(Status.Idle);
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.startGameplay == true && GameManager._blackoutInEffect == false)
        {
            if (Cheats.FlyModeEnabled == false)
            {
                BasicMovement();
            }
            else
            {
                FlyingMovement();
            }
        }
    }

    private void FlyingMovement()
    {
        //Debug.Log("Cheat is incomplete for now and simply makes you move faster");
        pMove.Move(pInput.input, (status == Status.Flying));
    }

    private void BasicMovement()
    {
        pMove.Move(pInput.input);
    }
}
