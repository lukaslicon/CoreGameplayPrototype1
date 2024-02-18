using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;  // Reference to the door's Animator component
    public Animator FloorAnimator;

    // This function is called when another Collider enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the specific game object you want to trigger the door
        if (other.CompareTag("BlueBall"))
        {
            // Trigger the "Open" animation in the doorAnimator
            doorAnimator.SetTrigger("DoorOpen");
            FloorAnimator.SetTrigger("Platform");
        }
    }
}
