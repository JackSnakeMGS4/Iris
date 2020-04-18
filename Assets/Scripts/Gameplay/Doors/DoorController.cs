using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private int doorID;
    public int _doorID { get { return doorID; } }

    [Header("Door Parts")]
    [SerializeField] private DoorFace doorFace;
    [SerializeField] private DoorKnob[] doorKnob;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    void Start()
    {
        DoorEvents.current.onDoorKnobInteraction += OnDoorKnobInteraction;
        DoorEvents.current.onDoorFaceInteraction += OnDoorFaceInteraction;
    }

    private void OnDoorKnobInteraction(int id)
    {
        if (id == doorID)
        {
            animator.ResetTrigger("Close Door");
            animator.SetTrigger("Open Door");
            animator.SetBool("Door Closed", false);
        }
    }

    private void OnDoorFaceInteraction(int id)
    {
        if (id == doorID)
        {
            animator.ResetTrigger("Open Door");
            animator.SetTrigger("Close Door");
            animator.SetBool("Door Closed", true);
        }
    }

    public void HandleDoorInteraction(LayerMask doorPartHit, Collider col)
    {
        if (doorPartHit == doorFace.gameObject.layer)
        {
            doorFace.CloseDoor();
        }
        else if (doorPartHit == doorKnob[0].gameObject.layer && animator.GetBool("Door Closed"))
        {
            if (col.gameObject == doorKnob[0].gameObject)
            {
                doorKnob[0].OpenDoor();
            }
            else
            {
                doorKnob[1].OpenDoor();
            }
        }
    }
}
