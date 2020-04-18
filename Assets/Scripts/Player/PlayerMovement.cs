using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Dev Related Fields")]
    [SerializeField] private float flyingSpeed = 10.0f;

    [Header("Movement Related Fields")]
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float gravity = 5.0f;

    [Header("Animator Fields")]
    [SerializeField] private Animator pAnimator;

    private Vector3 moveDir = Vector3.zero;
    private CharacterController charController;
    private Vector3 contactPoint;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    public void Teleport(Transform location)
    {
        //TODO: Something in the relapse/glitch event code logic is causing this teleport method from working properly
        //Debug.Log(transform.position);
        transform.position = location.position;
        //Debug.Log(transform.position);
    }

    public void Move(Vector2 input)
    {
        if(grounded)
        {
            if(pAnimator != null)
            {
                pAnimator.SetFloat("Input X", input.x);
                pAnimator.SetFloat("Input Y", input.y);
            }
            moveDir = new Vector3(input.x, 0.0f, input.y);
            moveDir = transform.TransformDirection(moveDir) * walkSpeed;
        }

        moveDir.y -= gravity * Time.deltaTime;

        grounded = (charController.Move(moveDir * Time.deltaTime) & CollisionFlags.Below) != 0;
    }

    public void Move(Vector2 input, bool flying)
    {
        moveDir = transform.right * input.x + transform.forward * input.y;
        moveDir.y -= gravity * Time.deltaTime;

        charController.Move(moveDir * flyingSpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contactPoint = hit.point;
    }
}
