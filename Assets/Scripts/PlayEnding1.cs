using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayEnding1 : MonoBehaviour
{
    [SerializeField] private PlayableDirector endingOne;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
        yield return new WaitForSeconds(1.5f);
        GameManager._blackoutInEffect = true;
        yield return new WaitForSeconds(4.0f);
        endingOne.Play();
    }
}
