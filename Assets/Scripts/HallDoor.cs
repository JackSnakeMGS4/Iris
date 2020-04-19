using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallDoor : MonoBehaviour
{
    private Animator a;

    private void Start()
    {
        a = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if(DoorKnob._canOpenDoor)
        {
            a.SetTrigger("Open Hall Door");
        }
        else
        {
            //play audio... maybe
        }
    }
}
