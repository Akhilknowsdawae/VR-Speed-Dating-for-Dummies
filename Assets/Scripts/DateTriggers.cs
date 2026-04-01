using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTriggers : MonoBehaviour
{
    public GameObject teleportSpots;
    public GameObject dateUI_A;
    public GameObject dateUI_B;

    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        teleportSpots.SetActive(false);
        dateUI_B.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToFirstDate()
    {
        Debug.Log("Going to second date!");
        Vector3 newPos = new Vector3(-1.45299995f, -6.69899988f, 3.78800011f);
        Vector3 oldPos = new Vector3(3f, -6.69899988f, 3.78800011f);

        StartCoroutine( CrossfadeTransition(newPos) );

        
        dateUI_A.SetActive(true);
        dateUI_B.SetActive(false);
    }
    public void GoToSecondDate()
    {
        Debug.Log("Going to second date!");
        Vector3 oldPos = new Vector3(-1.45299995f, -6.69899988f, 3.78800011f);
        Vector3 newPos = new Vector3(3f, -6.69899988f, 3.78800011f);

        StartCoroutine( CrossfadeTransition(newPos) );

        
        dateUI_A.SetActive(false);
        dateUI_B.SetActive(true);
    }

    IEnumerator CrossfadeTransition(Vector3 newPos)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        transform.position = newPos;
    }
}
