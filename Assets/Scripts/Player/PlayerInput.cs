using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float movementSensity = 0.5f;

    public Vector2 input
    {
        get
        {
            Vector2 input = Vector2.zero;
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            if(input.x != 0.0f && input.y != 0.0f)
            {
                input *= movementSensity;
            }
            else
            {
                input *= 1.0f;
            }

            return input;
        }
    }

    public Vector2 rawInput
    {
        get
        {
            Vector2 raw = Vector2.zero;
            raw.x = Input.GetAxisRaw("Horizontal");
            raw.y = Input.GetAxisRaw("Vertical");

            if(raw.x != 0.0f && raw.y != 0.0f)
            {
                raw *= movementSensity;
            }
            else
            {
                raw *= 1.0f;
            }

            return raw;
        }
    }

    public static Vector2 mouseWheel
    {
        get
        {
            Vector2 mW = Input.mouseScrollDelta;

            return mW;
        }
    }

    public bool fly { get { return Cheats.FlyModeEnabled; } }
    public static bool isAimingLight { get { return Input.GetButton("Aim Light"); } }
    public static bool useLight { get { return Input.GetButton("Use Light"); } }
    public static bool interact { get { return Input.GetButtonDown("Interact"); } }

    private Vector2 previous;

    private void Update()
    {
        if(rawInput.x != previous.x)
        {
            previous.x = rawInput.x;
        }
        if(rawInput.y != previous.y)
        {
            previous.y = rawInput.y;
        }
    }
}
