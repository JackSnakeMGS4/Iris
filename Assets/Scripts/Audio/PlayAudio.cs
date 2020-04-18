using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] [EventRef] private string eventFilepath;
    [SerializeField] private Transform audioLocation;
    [SerializeField] private bool isOneShot;

    private EventInstance thisEvent;
    private bool hasEventPlayed = false;

    private void Awake()
    {
        if (eventFilepath != null)
        {
            if (!isOneShot)
                thisEvent = RuntimeManager.CreateInstance(eventFilepath);
        }
    }

    private void Start()
    {
        if (eventFilepath != null)
        {
            if (!isOneShot)
                thisEvent.set3DAttributes(RuntimeUtils.To3DAttributes(audioLocation));
        }
    }

    // parameter for fmod even in case audio cue relies on another system
    public void CueAudio(string extraEvent1 = null)
    {
        if(extraEvent1 != null && isOneShot)
        {
            RuntimeManager.PlayOneShot(extraEvent1, audioLocation.position);
        }
        else
        {
            if(eventFilepath != null)
            {
                RuntimeManager.PlayOneShot(eventFilepath, audioLocation.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOneShot && eventFilepath != null && hasEventPlayed == false)
            {
                Debug.Log("Playing one shot");
                RuntimeManager.PlayOneShot(eventFilepath, audioLocation.position);
                hasEventPlayed = true;
            }
        }
    }
}
