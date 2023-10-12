using System.Collections;
using UnityEngine;

public class DisappearOnKeyPress : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject you want to disappear

    private void Start()
    {
        // Make the object initially visible
        SetObjectVisibility(true);
    }

    private void Update()
    {
        // Check if 'M' button is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(HideObjectAfterDelay());
        }
    }

    private void SetObjectVisibility(bool isVisible)
    {
        // Toggle the object's visibility by enabling/disabling its renderer component
        if (targetObject != null)
        {
            Renderer renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = isVisible;
            }
        }
    }

    // This coroutine hides the object after 7 seconds
    private IEnumerator HideObjectAfterDelay()
    {
        yield return new WaitForSeconds(7f); // Wait for 7 seconds
        SetObjectVisibility(false); // Hide the object
    }
}
