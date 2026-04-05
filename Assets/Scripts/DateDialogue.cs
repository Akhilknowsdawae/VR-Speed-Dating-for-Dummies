using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using Ink.UnityIntegration;

public class DateDialogue : MonoBehaviour
{
    //Followed tutorial:
    // https://www.youtube.com/playlist?list=PL3viUl9h9k78KsDxXoAzgQ1yRjhm7p8kl


    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueBtn;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextAsset inkJSON;
    private Story currentStory;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private DialogueVariables dialogueVariables;
    [SerializeField] private InkFile globalsInkFile;
    [SerializeField] private GameObject VROrigin;
    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject rose;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();

        //choicesText = new TextMeshProUGUI[choices.Length];
        //int index = 0;
        //foreach (GameObject choice in choices)
        //{
        //    choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();            
        //    Debug.Log(choicesText.Length);
        //    //Debug.Log("Populating " + choice.name + " with " + choicesText[index]);
        //    index++;
        //}
        //LOOK I DON'T KNOW WHY
        //BUT THIS NULLIFIES choicesText SOMETIME AFTER THIS. DRIVING ME INSANE
        //so. I have moved this whole function to the displaychoices func
        //load-bearing coconut i guess
    }

    void Awake()
    {
        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
    }

    public void StartDialogue()
    {
        currentStory = new Story(inkJSON.text);
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        ContinueDialogue();
    }

    public void ContinueDialogue()
    {
        //If we end up having multiple text boxes, call this on "next" button press
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            CheckForTags();
        }
        else
        {            
            Debug.LogError("End of dialogue!");            
            dialogueVariables.StopListening(currentStory); //if another exit function, put this there instead
        }
        
    }

    private void CheckForTags()
    {
        foreach (string tag in currentStory.currentTags)
        {
            Debug.Log("Found tag " + tag);

            // Handle animation tags
            if (tag.StartsWith("anim"))
            {
                int index = int.Parse(tag.Substring(4));
                if (npc != null && npc.GetComponent<NPCAnimations>() != null)
                {
                    npc.GetComponent<NPCAnimations>().PlayAnimation(index);
                }
                continue; // Skip the switch for animation tags
            }

            switch (tag) {

                case "goToDateA":
            
                    Debug.Log("Going to first date!");
                    if(VROrigin != null)
                    {
                        dialogueVariables.StopListening(currentStory);
                        VROrigin.GetComponent<DateTriggers>().GoToFirstDate();
                    }
                    else
                    {
                        Debug.LogWarning("VR Origin is null idiot");
                    }
                    break;

                case "goToDateB":
            
                    Debug.Log("Going to second date!");
                    if (VROrigin != null)
                    {
                        dialogueVariables.StopListening(currentStory);
                        VROrigin.GetComponent<DateTriggers>().GoToSecondDate();
                    }
                    else
                    {
                        Debug.LogWarning("VR Origin is null idiot");
                    }
                    break;

                case "goToDateC":
                    Debug.Log("Going to third date!");
                    if (VROrigin != null)
                    {
                        dialogueVariables.StopListening(currentStory);
                        VROrigin.GetComponent<DateTriggers>().GoToThirdDate();
                    }
                    else
                    {
                        dialogueVariables.StopListening(currentStory);
                        Debug.LogWarning("VR Origin is null idiot");
                    }
                    break;

                case "goToDateD":
                    Debug.Log("Going to fourth date!");
                    if (VROrigin != null)
                    {
                        VROrigin.GetComponent<DateTriggers>().GoToFourthDate();
                    }
                    else
                    {
                        Debug.LogWarning("VR Origin is null idiot");
                    }
                    break;

                case "goToHost":
            
                    Debug.Log("Going to host!");
                    if (VROrigin != null)
                    {
                        VROrigin.GetComponent<DateTriggers>().GoToHost();
                    }
                    else
                    {
                        Debug.LogWarning("VR Origin is null idiot");
                    }
                    break;

                case "closeHostDialogue":

                    Debug.Log("Closing host dialogue!");
                    gameObject.SetActive(false);
                    break;

                case "rose":

                    Debug.Log("Rose!");
                    VROrigin.GetComponent<DateTriggers>().teleportSpots.SetActive(true);
                    rose.SetActive(true);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > 0)
        {
            continueBtn.SetActive(false);
        }
        else
        {
            continueBtn.SetActive(true);
        }

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too many choices (" + currentChoices.Count + ")for current UI.");
        }

        //Being load-bearing coconut
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            //Debug.Log(choicesText.Length);
            //Debug.Log("Populating " + choice.name + " with " + choicesText[index]);
            index++;
        }
        //end load-bearing coconut

        index = 0;
        foreach (Choice choice in currentChoices)
        {            
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i< choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueDialogue();
        //currentStory.MakeChoice(choiceIndex);
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink var " + variableName + " was null!");
        }
        return variableValue;
    }
    //When we need to get the score later, use some variant of this
    //int dateAScore = ((Ink.Runtime.IntValue)dateUI_A.GetComponent<DateDialogue>().GetVariableState("dateAScore")).value;
}
