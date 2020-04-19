using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayEnding1 : MonoBehaviour
{
    [SerializeField] private PlayableDirector endingTwo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //endingTwo.Play();
        }
    }
}
