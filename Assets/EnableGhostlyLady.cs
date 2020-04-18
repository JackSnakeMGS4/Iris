using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGhostlyLady : MonoBehaviour
{
    [SerializeField] private GameObject lady;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lady.SetActive(true);
        }
    }
}
