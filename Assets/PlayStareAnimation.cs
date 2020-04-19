using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStareAnimation : MonoBehaviour
{
    [SerializeField] private Animator a;

    public void Stare()
    {
        a.SetTrigger("Stare");
    }
}
