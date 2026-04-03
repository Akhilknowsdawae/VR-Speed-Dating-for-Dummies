using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DateTriggers : MonoBehaviour
{
    //Followed tutorial:
    // https://www.youtube.com/playlist?list=PL3viUl9h9k78KsDxXoAzgQ1yRjhm7p8kl

    public GameObject teleportSpots;
    public GameObject dateUI_A;
    public GameObject dateUI_B;

    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        teleportSpots.SetActive(false);
        dateUI_A.SetActive(false);
        dateUI_B.SetActive(false);
        GoToFirstDate(); //for testing TODO

        //int dateAScore = ((Ink.Runtime.IntValue)dateUI_A.GetComponent<DateDialogue>().GetVariableState("dateAScore")).value;
        //Debug.LogError("DATE A SCORE IS " + dateAScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToFirstDate()
    {
        GoToDate(1);
    }
    public void GoToSecondDate()
    {
        GoToDate(2);
    }

    public void GoToDate(int idx)
    {
        Debug.Log("Going to date: " +idx);

        Vector3 newPos = new Vector3(0, 0, 0);
        dateUI_A.SetActive(false);
        dateUI_B.SetActive(false);
        GameObject activeUI = null;

        switch (idx)
        {
            case 1:
                newPos = new Vector3(-1.45299995f, -6.69899988f, 3.78800011f);
                //dateUI_A.SetActive(true);
                activeUI = dateUI_A;
                break;

            case 2:
                newPos = new Vector3(3f, -6.69899988f, 3.78800011f);
                //dateUI_B.SetActive(true);
                activeUI = dateUI_B;
                break;
                //add more for dates 3 and 4 TODO
        }

        StartCoroutine( CrossfadeTransition(newPos) );

        if (activeUI != null)
        {
            activeUI.SetActive(true);
            DateDialogue ddScript = activeUI.GetComponent<DateDialogue>();
            if (ddScript != null)
            {
                ddScript.StartDialogue();
            }
        }

    }

    

    IEnumerator CrossfadeTransition(Vector3 newPos)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        transform.position = newPos;
    }
}
