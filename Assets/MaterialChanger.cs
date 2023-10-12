using System.Collections;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material newMaterial;// The material to change to after pressing 'M'
    public Material originalMaterial;
    private Renderer objectRenderer;
    private bool materialChanged = false;
    private bool mPressed = false;
    private float timeElapsed = 0f;
    private float transitionTimeElapsed = 0f;
    public float changeDelay = 4f; // Delay before changing the material after pressing 'M'
    public float transitionDuration = 2f; // Duration of the material transition
    private Color originalColor; // Store the original color

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material; // Store the original material
        originalColor = objectRenderer.material.color; // Store the original color
    }

    void Update()
    {
        if (!materialChanged)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") && !mPressed)
            {
                mPressed = true;
                timeElapsed = 0f; // Reset the timer when 'M' is pressed
            }

            if (mPressed)
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= changeDelay)
                {
                    TransitionMaterial();
                }
            }
        }
    }

    void TransitionMaterial()
    {
        transitionTimeElapsed += Time.deltaTime;

        if (transitionTimeElapsed <= transitionDuration)
        {
            // Calculate the lerp t value for the transition
            float t = transitionTimeElapsed / transitionDuration;
            objectRenderer.material.Lerp(originalMaterial, newMaterial, t); // Use original material as the starting point
        }
        else
        {
            objectRenderer.material = newMaterial;
            materialChanged = true;
        }
    }

    // Function to reset material/color to the original state
    void ResetMaterial()
    {
        objectRenderer.material = originalMaterial;
        objectRenderer.material.color = originalColor;
        materialChanged = false;
        mPressed = false;
    }

    // Call this function when you want to reset the material/color
    public void ResetMaterialOnClick()
    {
        ResetMaterial();
    }
}
