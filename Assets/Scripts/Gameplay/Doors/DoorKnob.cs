using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnob : MonoBehaviour
{
    [SerializeField] [FMODUnity.EventRef] private string responseToKnobInteractions;
    [SerializeField] private PlayAudio myAudio;

    private DoorController myDC;
    private static bool canOpenDoor = false;
    public static bool _canOpenDoor { set { DoorKnob.canOpenDoor = value; } }

    private int numberOfInteractions;

    private void Awake()
    {
        myDC = GetComponentInParent<DoorController>();
    }

    private void Start()
    {
        numberOfInteractions = 0;
    }

    public void OpenDoor()
    {
        if (canOpenDoor)
        {
            DoorEvents.current.DoorKnobInteraction(myDC._doorID);
        }
        else
        {
            numberOfInteractions++;
            if(numberOfInteractions == 2)
            {
                //Debug.Log("Playing audio event");
                myAudio.CueAudio(responseToKnobInteractions);
                // Lock player controls (since they're in a cutscene) ,Play glitch cutscene, fade to black, place player on sofa, 
                // play animation for camera checking surroundings (FYI: You'll need to do this within coroutine so it doesn't run everything instantly)
            }
        }
    }
}
