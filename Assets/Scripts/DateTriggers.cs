using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTriggers : MonoBehaviour
{
    public GameObject teleportSpots;
    public GameObject dateUIa;
    public GameObject dateUIb;
    // Start is called before the first frame update
    void Start()
    {
        teleportSpots.SetActive(false);
        dateUIb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToSecondDate()
    {
        Debug.Log("Going to second date!");
        Vector3 oldPos = new Vector3(-1.45299995f, -6.69899988f, 3.78800011f);
        Vector3 newPos = new Vector3(3f, -6.69899988f, 3.78800011f);
        transform.position = newPos;
        dateUIa.SetActive(false);
        dateUIb.SetActive(true);
    }
}
