using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    //Singleton
    public static DoorEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onDoorKnobInteraction;
    public void DoorKnobInteraction(int id)
    {
        if(onDoorKnobInteraction != null)
        {
            onDoorKnobInteraction(id);
        }
    }

    public event Action<int> onDoorFaceInteraction;
    public void DoorFaceInteraction(int id)
    {
        if(onDoorFaceInteraction != null)
        {
            onDoorFaceInteraction(id);
        }
    }
}
