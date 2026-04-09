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
    public GameObject dateUI_C;
    public GameObject dateUI_D;
    public GameObject hostUI;
    public GameObject mainCamera;

    public Animator transition;
    public float transitionTime = 1f;
    private GameObject activeUI = null;
    [SerializeField] private GameObject hostMannequin;

    // Start is called before the first frame update
    void Start()
    {
        teleportSpots.SetActive(false);
        dateUI_A.SetActive(false);
        dateUI_B.SetActive(false);
        dateUI_C.SetActive(false);
        dateUI_D.SetActive(false);
        activeUI = hostUI;

        //start at host
        activeUI = hostUI;
        hostMannequin.SetActive(true);
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
        mainCamera.transform.position = new Vector3(0f, 0f, 0f);
        gameObject.transform.Translate(-2.5f, -6.4f, 0f, Space.World);
        transform.rotation = Quaternion.Euler(0f, 150f, 0f);

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
    public void GoToThirdDate()
    {
        GoToDate(3);
    }
    public void GoToFourthDate()
    {
        GoToDate(4);
    }
    public void GoToHost()
    {
        GoToDate(0);
    }
    public void GoToOutcome()
    {
        GoToDate(-1);
    }

    private void GoToDate(int idx)
    {
        Debug.Log("Going to date: " +idx);

        Vector3 newPos = new Vector3(0, 0, 0);
        float newRot = 0f;
        dateUI_A.SetActive(false);
        dateUI_B.SetActive(false);
        dateUI_C.SetActive(false);
        dateUI_D.SetActive(false);
        hostUI.SetActive(false);
        //hostMannequin.SetActive(false);
        

        switch (idx)
        {
            case 1:
                //Job
                newPos = new Vector3(-1.45299995f, -6.69899988f, 3.78800011f);
                newRot = 90f;
                activeUI = dateUI_A;
                break;

            case 2:
                //Villian
                newPos = new Vector3(5.1f, -6.69899988f, 3.79f);
                newRot = 270f;
                activeUI = dateUI_B;
                break;
            case 4:
                //Japanese
                newPos = new Vector3(3.21f, -6.69899988f, -3.93f);
                newRot = 90f;
                activeUI = dateUI_C;
                break;
            case 3:
                //Cop
                newPos = new Vector3(-0.84f, -6.69899988f, -3.91f);
                newRot = 270f;
                activeUI = dateUI_D;
                break;
            case -1:
                //Success or fail
                newPos = new Vector3(5.819f, 16.25f, -1.15f);
                newRot = 0f;
                activeUI = null;
                break;
            default:
                Debug.Log("Idx invalid, returning to host.");
                newPos = new Vector3(-2.5f, -6.4f, 0f);
                newRot = 150f;
                activeUI = hostUI;
                hostMannequin.SetActive(true);
                break;
        }

        StartCoroutine( CrossfadeTransition(newPos, newRot));       

    }

    

    IEnumerator CrossfadeTransition(Vector3 newPos, float newRot)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        //Debug.Log("new pos is" + newPos);
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
        mainCamera.transform.position = new Vector3(0f, 0f, 0f);
        //Debug.Log("Is it zeroed? Is: " +gameObject.transform.position); 
        gameObject.transform.Translate(newPos, Space.World);
        transform.rotation = Quaternion.Euler(0f, newRot, 0f);
        //transform.rotation += newRot;
        if (activeUI != null)
        {
            activeUI.SetActive(true);
            DateDialogue ddScript = activeUI.GetComponent<DateDialogue>();
            if (ddScript != null)
            {
                ddScript.StartDialogue();
            }
            if(activeUI != hostUI)
            {
                hostMannequin.SetActive(false);
            }
        }
    }
}
