using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnFall : MonoBehaviour
{
    public Vector3 startingPosition = new Vector3(0f, 5f, 0f);
    public float respawnYThreshold = -10f;

    void Update()
    {
        if (transform.position.y < respawnYThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Reset the object's position to the starting position
        transform.position = startingPosition;
        // You might want to add additional reset logic here if needed
    }
}