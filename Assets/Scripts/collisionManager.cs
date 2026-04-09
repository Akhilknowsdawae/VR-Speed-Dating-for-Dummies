using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    [SerializeField] private GameObject rose;
    [SerializeField] private GameObject rose2;
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
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateJobScore")).value;
                Debug.Log("Date Job Score is: " + score);
                rose2.SetActive(true);
                rose2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rose2.transform.position = new Vector3(-0.587732494f, -5.8654f, 3.26321173f);
                if (score < 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToFirstDate();
                //rose.transform.localScale = new Vector3(0.2,0.2,0.2);
                //rose.transform = new Vector3(-1.73,-5.8,-3.43);
            }
            else if (usingUI.name == "Date UI B")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateVillainScore")).value; 
                Debug.Log("Date Villain Score is: " + score);
                rose2.SetActive(true);
                rose2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rose2.transform.position = new Vector3(4.12200022f, -5.80200005f, 3.1730001f);
                if (score < 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToSecondDate();
            }
            else if (usingUI.name == "Date UI C")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateJapaneseScore")).value; 
                Debug.Log("Date Japanese Score is: " + score);
                rose2.SetActive(true);
                rose2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rose2.transform.position = new Vector3(4.16001129f, -5.84989977f, -3.45409989f);
                if (score < 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToFourthDate();
            }
            else if (ddScript.name == "Date UI D")
            {
                score = ((Ink.Runtime.IntValue)ddScript.GetVariableState("dateCopScore")).value; 
                Debug.Log("Date Cop Score is: " + score);
                rose2.SetActive(true);
                rose2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rose2.transform.position = new Vector3(-1.72909999f, -5.78299999f, -3.43700004f);
                if (score < 0)
                    ddScript.failureState = true;
                else
                    ddScript.successState = true;
                ddScript.VROrigin.GetComponent<DateTriggers>().GoToThirdDate();
            }
            else
            {
                Debug.Log("ERROR FINDING CORRECT UI");
            }

        }
    }


}
