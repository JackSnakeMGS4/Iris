using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpook : MonoBehaviour
{
    [SerializeField] private List<Transform> teleportPositions;
    [SerializeField] private Transform player;
    private int teleportCount = 0;

    public void Teleport()
    {
        if(teleportCount == 0)
        {
            transform.position = teleportPositions[0].position;
        }
        else if(teleportCount == 1)
        {
            transform.position = teleportPositions[1].position;
        }

        transform.right = Vector3.zero;
        transform.LookAt(player.position);
        teleportCount++;
    }
}
