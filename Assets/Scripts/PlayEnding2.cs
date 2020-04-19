using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayEnding2 : MonoBehaviour
{
    [SerializeField] private PlayableDirector endingTwo;

    public static bool ending2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(WaitBeforeLockingControls());
            //endingTwo.Play();
        }
    }

    public void StopCoroutine()
    {
        StopCoroutine(WaitBeforeLockingControls());
    }

    IEnumerator WaitBeforeLockingControls()
    {
        yield return new WaitForSeconds(3.0f);
        GameManager._blackoutInEffect = true;
        ending2 = true;
        yield return new WaitForSeconds(4.0f);
        endingTwo.Play();
    }
}
