using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGhostlyLady : MonoBehaviour
{
    [SerializeField] private GameObject lady;
    [SerializeField] private GameObject fakeWall;

    private BoxCollider col;

    private int triggerExitedTimes = 0;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerExitedTimes == 0)
            {
                lady.SetActive(true);
            }
            else if (triggerExitedTimes > 0)
            {
                lady.SetActive(false);
                fakeWall.SetActive(false);
                col.enabled = false;
            }

            triggerExitedTimes++;
        }
    }
}
