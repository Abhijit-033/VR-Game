using System.Collections;
using UnityEngine;

public class MoveObjectOnPress : MonoBehaviour
{
    public float targetZPosition = 0.632f;
    public float moveDuration = 3f;

    private Vector3 initialPosition;
    private float elapsedTime = 0f;
    private bool isMoving = false;

    private void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Check if 'M' button is pressed
        if (Input.GetKeyDown(KeyCode.M) && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveObjectToTargetPos());
        }
    }

    private IEnumerator MoveObjectToTargetPos()
    {
        elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            // Calculate the new position using Lerp
            float t = elapsedTime / moveDuration;
            Vector3 newPosition = Vector3.Lerp(initialPosition, new Vector3(initialPosition.x, initialPosition.y, targetZPosition), t);

            // Update the object's position
            transform.position = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object reaches the exact target position
        transform.position = new Vector3(initialPosition.x, initialPosition.y, targetZPosition);

        isMoving = false;
    }
}

