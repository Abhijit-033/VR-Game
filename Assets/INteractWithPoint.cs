using UnityEngine;
using System.Collections;
//using MyNameS; // Import the namespace where MovePlayer is defined

public class InteractWithPoint : MonoBehaviour
{
   // public Transform playerTransform; // Reference to the player's Transform

    public void OnMouseDown()
    {
        // This method is called when the GameObject is clicked with the mouse.
        // You can trigger your action here.
        Debug.Log("Clicked on the specific point!");

        // Call the MoveToTargetPosition function from MovePlayer
       // StartCoroutine(MovePlayer.MoveToTargetPosition(playerTransform, 0.632f, 3f));
    }
}
