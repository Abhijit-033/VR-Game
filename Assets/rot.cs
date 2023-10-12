using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 45f, 0f); // Degrees per second, adjust as needed

    private void Update()
    {
        // Rotate the object continuously
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

