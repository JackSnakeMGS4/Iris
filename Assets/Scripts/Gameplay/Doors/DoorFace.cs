using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFace : MonoBehaviour
{
    private DoorController myDC;

    private void Awake()
    {
        myDC = GetComponentInParent<DoorController>();
    }

    public void CloseDoor()
    {
        DoorEvents.current.DoorFaceInteraction(myDC._doorID);
    }
}
