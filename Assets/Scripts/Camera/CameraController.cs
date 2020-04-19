using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform p;
    [SerializeField] private PlayerController pControl;

    [Header("Movement Cam Fields")]
    [SerializeField] private float mouseSensitivity = 100.0f;
    [SerializeField] private float zoomRate = 0.5f;
    [SerializeField] private float zoomSensitivity = 50.0f;
    [SerializeField] private float zoomLerpTime = 1.0f;
    [SerializeField] private Vector2 zoomClamp = new Vector2(25f, 38f);

    [Header("Other Camera Fields")]
    [SerializeField] private CinemachineVirtualCamera movementCam;
    [SerializeField] private Vector2 clampX = new Vector2(-30f, 30f);
    [SerializeField] private Vector2 clampY = new Vector2(-45f, 45f);

    [Header("Camera Light")]
    [SerializeField] private GameObject camLight;
    [SerializeField] private float lightAimSensitivity = 50.0f;

    private float xRot = 0.0f;
    private float yRot = 0.0f;

    private float lastFOV;
    private float newFOV;

    // Used with SmoothDamp
    private float vel = 1.0f;
    #endregion

    #region Mouse Input Properties
    public Vector2 mouse
    {
        get
        {
            Vector2 m = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            return m;
        }
    }

    public Vector2 mouseRaw
    {
        get
        {
            Vector2 mR = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            return mR;
        }
    }
    #endregion

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if ((PlayerInput.interact == false && GameManager.startGameplay == true && GameManager._blackoutInEffect == false) || PlayEnding2.ending2 == true)
        {
            UpdateCamLight();
            ZoomCamIfChanged();
            RotateBody(pControl.moveStatus);
        }
    }

    private void ZoomCamIfChanged()
    {
        lastFOV = movementCam.m_Lens.FieldOfView;
        newFOV = lastFOV;

        //Debug.Log(PlayerInput.mouseWheel);
        if (PlayerInput.mouseWheel.y > 0.0f)
        {
            //Debug.Log("Zooming in");
            // Lower FOV value
            newFOV -= zoomRate * Time.deltaTime * zoomSensitivity;
        }
        else if (PlayerInput.mouseWheel.y < 0.0f)
        {
            // Increase FOV value
            newFOV += zoomRate * Time.deltaTime * zoomSensitivity;
        }
        newFOV = Mathf.Clamp(newFOV, zoomClamp.x, zoomClamp.y);

        movementCam.m_Lens.FieldOfView = Mathf.SmoothDamp(lastFOV, newFOV, ref vel, zoomLerpTime);
    }

    private void RotateBody(Status status)
    {
        //Debug.Log(POV.m_HorizontalAxis.Value);
        //Debug.Log(POV.m_VerticalAxis.Value);

        float mouseX;
        float mouseY;

        mouseX = mouse.x * mouseSensitivity * Time.deltaTime;
        mouseY = mouse.y * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, clampY.x, clampY.y);

        movementCam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        p.Rotate(Vector3.up, mouseX);
    }

    private void UpdateCamLight()
    {
        //TODO: Have spotlight and Zoom camera inherit rotation from POV camera
        //TODO: Implement aim damping

        float aimX = mouse.x * lightAimSensitivity * Time.deltaTime;
        float aimY = mouse.y * lightAimSensitivity * Time.deltaTime;

        xRot -= aimY;
        xRot = Mathf.Clamp(xRot, clampY.x, clampY.y);
        yRot += aimX;
        yRot = Mathf.Clamp(yRot, clampX.x, clampX.y);

        camLight.transform.localRotation = Quaternion.Euler(xRot, yRot, 0.0f);
    }
}
