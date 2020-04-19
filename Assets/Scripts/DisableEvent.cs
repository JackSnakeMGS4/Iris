using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEvent : MonoBehaviour
{

    private BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();   
    }

    private void OnTriggerExit(Collider other)
    {
        col.enabled = false;
    }
}
