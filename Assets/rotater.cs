using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    private Renderer objectRenderer;
    private bool isVisible = false;

    void Start()
    {
        // Get the object's renderer component
        objectRenderer = GetComponent<Renderer>();

        // Ensure the object is initially invisible
        SetObjectVisibility(false);
    }

    void Update()
    {
        // Check if 'M' key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle visibility
            isVisible = !isVisible;
            SetObjectVisibility(isVisible);
        }
    }

    void SetObjectVisibility(bool visible)
    {
        // Enable or disable the renderer component to change visibility
        if (objectRenderer != null)
        {
            objectRenderer.enabled = visible;
        }
    }
}
