using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallLady : MonoBehaviour
{
    private BoxCollider col;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            col.enabled = false;
        }
    }
}
