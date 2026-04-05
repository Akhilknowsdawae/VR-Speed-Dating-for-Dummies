using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRose : MonoBehaviour
{
    public bool hasBeenGrabbed = false;
    private float floatVal;
    private bool goingUp;
    private float increment;
    // Start is called before the first frame update
    void Start()
    {
        floatVal = 0f;
        increment = 0.0005f;
        //gameObject.SetActive(false);
    }

    public void RoseGrabbed()
    {
        Debug.Log("Grabbed Rose!");
        hasBeenGrabbed = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenGrabbed)
        {
            if (goingUp)
            {
                floatVal += increment;
            }
            else
            {
                floatVal -= increment;
            }

            if(floatVal > 0.09f || floatVal < -0.09f)
            {
                increment = 0.0002f;
            }
            else
            {
                increment = 0.0005f;
            }

            if (floatVal > 0.1f || floatVal < -0.1f)
            {
                goingUp = !goingUp;
            }
            
            gameObject.transform.position = new Vector3(-2.13700008f, -5.75199986f, -1.35699999f);
            gameObject.transform.position += new Vector3(0f, floatVal, 0f);
        }
    }
}
