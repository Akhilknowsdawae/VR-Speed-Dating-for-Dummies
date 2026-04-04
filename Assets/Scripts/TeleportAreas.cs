using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAreas : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject User;
    private GameObject TeleportArea;
    private float distThreshold = 3f;
    void Start()
    {
        TeleportArea = gameObject;
        if (User == null)
        {
            User = GameObject.Find("Main Camera");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (User != null)
        {
            float dist = Vector3.Distance(User.transform.position, TeleportArea.transform.position);

            if (dist<=distThreshold)
            {
                //Debug.Log("Close to " + TeleportArea.name + ", " +dist);
                TeleportArea.GetComponent<MeshRenderer>().enabled = false;
                TeleportArea.GetComponent<CapsuleCollider>().enabled = false;
            }
            else
            {
                //Debug.Log("Far from " + TeleportArea.name + ", " + dist);
                TeleportArea.GetComponent<MeshRenderer>().enabled = true;
                TeleportArea.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
    }
}
