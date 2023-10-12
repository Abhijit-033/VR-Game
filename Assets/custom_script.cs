using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custom_script : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") >0)
        {
            player.transform.position = player.transform.position + new Vector3(2*Time.deltaTime, 0, 0);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            player.transform.position = player.transform.position + new Vector3(-2 * Time.deltaTime, 0, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            player.transform.position = player.transform.position + new Vector3(0, 0 , -2 * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            player.transform.position = player.transform.position + new Vector3(0, 0 , 2 * Time.deltaTime);
        }
    }
}
