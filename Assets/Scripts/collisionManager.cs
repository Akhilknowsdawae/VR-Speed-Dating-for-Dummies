using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    [SerializeField] private GameObject rose;
    [SerializeField] private GameObject UI_self;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coffeeCup")
        {
            Debug.Log(gameObject.name + " was hit by coffee! ");
            other.gameObject.SetActive(false);
            GameObject usingUI = UI_self;
            if (usingUI != null)
            {
                DateDialogue ddScript = usingUI.GetComponent<DateDialogue>();
                ddScript.dialogueText.text = "Ouch! That coffee is hot!";
            }
        }
        if (other.gameObject == rose)
        {
            Debug.Log(gameObject.name + " was hit by rose! ");
            rose.SetActive(false);
            GameObject usingUI = UI_self;
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
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateBScore")).value; 
                Debug.Log("Date Score is: " + score);
                if (score <= 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToSecondDate();
            }
            else if (usingUI.name == "Date UI C")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateCScore")).value; 
                Debug.Log("Date Score is: " + score);
                if (score <= 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToThirdDate();
            }
            else if (ddScript.name == "Date UI D")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateDScore")).value; 
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
