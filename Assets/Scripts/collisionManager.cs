using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    [SerializeField] private GameObject rose;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rose)
        {
            Debug.Log(gameObject.name + " was hit by rose! ");
            rose.SetActive(false);
            GameObject usingUI = gameObject.transform.GetChild(0).gameObject;
            DateDialogue ddScript = usingUI.GetComponent<DateDialogue>();
            int score;
            if (usingUI.name == "Date UI A")
            {
                
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateAScore")).value;
                Debug.Log("Date Score is: " + score);
                if (score <= 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToFirstDate();
            }
            else if (usingUI.name == "Date UI B")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateScoreB")).value; 
                Debug.Log("Date Score is: " + score);
                if (score <= 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToSecondDate();
            }
            else if (usingUI.name == "Date UI C")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateScoreC")).value; 
                Debug.Log("Date Score is: " + score);
                if (score <= 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToThirdDate();
            }
            else if (ddScript.name == "Date UI D")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateScoreD")).value; 
                Debug.Log("Date Score is: " + score);
                if (score <= 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToFourthDate();
            }
            else
            {
                Debug.Log("ERROR FINDING CORRECT UI");
            }

        }
    }


}
