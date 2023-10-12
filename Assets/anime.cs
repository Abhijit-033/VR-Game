using System.Collections;
using UnityEngine;

public class MoveAndFadeOnKeyPress : MonoBehaviour
{
    public Transform playerTransform;
    public float targetZPosition = 2f;
    public float moveDuration = 4f; // Extend move duration to 4 seconds
    public float fadeDelay = 0f;   // Delay before fading after movement

    private Vector3 initialPosition;
    private float elapsedTime = 0f;

    private bool isMoving = false;
    private bool isFading = false;

    private void Start()
    {
        // Store the initial position of the player
        initialPosition = playerTransform.position;
    }

    private void Update()
    {
        // Check if the player is not currently moving, fading, and a move is requested
        if (!isMoving && !isFading && Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(MoveAndFadePlayer());
        }
    }

    private IEnumerator MoveAndFadePlayer()
    {
        isMoving = true;
        elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            // Calculate the new position using Lerp
            float t = elapsedTime / moveDuration;
            Vector3 newPosition = Vector3.Lerp(initialPosition, new Vector3(initialPosition.x, initialPosition.y, targetZPosition), t);

            // Update the player's position
            playerTransform.position = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the player reaches the exact target position
        playerTransform.position = new Vector3(initialPosition.x, initialPosition.y, targetZPosition);

        // Delay before fading
        yield return new WaitForSeconds(fadeDelay);

        isFading = true;

        // Start fading
        yield return StartCoroutine(FadePlayer());

        isFading = false;

        // Reset the object's position and alpha
        playerTransform.position = initialPosition;
        Renderer playerRenderer = playerTransform.GetComponent<Renderer>();
        Color initialColor = playerRenderer.material.color;
        playerRenderer.material.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);
    }

    private IEnumerator FadePlayer()
    {
        Renderer playerRenderer = playerTransform.GetComponent<Renderer>();
        Color initialColor = playerRenderer.material.color;
        float fadeDuration = 3f; // 3-second fade duration

        float startTime = Time.time;
        float endTime = startTime + fadeDuration;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / fadeDuration;
            Color lerpedColor = Color.Lerp(initialColor, new Color(initialColor.r, initialColor.g, initialColor.b, 0f), t);
            playerRenderer.material.color = lerpedColor;

            yield return null;
        }

        // Ensure the object is completely faded
        Color finalColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
        playerRenderer.material.color = finalColor;

        isMoving = false;
    }
}
