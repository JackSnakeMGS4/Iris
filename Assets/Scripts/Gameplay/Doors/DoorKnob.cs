using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorKnob : MonoBehaviour
{
    [SerializeField] private PlayableDirector blackoutDirector;

    private DoorController myDC;
    private static bool canOpenDoor = false;
    public static bool _canOpenDoor { get { return DoorKnob.canOpenDoor; } set { DoorKnob.canOpenDoor = value; } }

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
                GameManager._blackoutInEffect = true;
                blackoutDirector.Play();
            }
        }
    }
}
