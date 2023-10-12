using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{
    public GameObject targetObject; // Reference to the 3D model or specific point you want to target.

    public void OnButtonClick()
    {
        // Trigger your action here, e.g., activating an animation on the target object.
        targetObject.GetComponent<Animator>().SetTrigger("ActivateAnimation");
    }
}
