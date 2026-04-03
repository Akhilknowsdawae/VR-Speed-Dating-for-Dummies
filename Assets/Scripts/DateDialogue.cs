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
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextAsset inkJSON;
    private Story currentStory;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private DialogueVariables dialogueVariables;
    [SerializeField] private InkFile globalsInkFile;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index++] = choice.GetComponentInChildren<TextMeshProUGUI>();
        }
        //int dateAScore = ((Ink.Runtime.IntValue)GetVariableState("test")).value;
        //Debug.Log("DATE A SCORE IS " + dateAScore);
        //string testString = ((Ink.Runtime.StringValue)GetVariableState("testString")).value;
        //Debug.Log("TEST STRING IS " + testString);
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
        }
        else
        {
            //do exit stuff here TODO
            dialogueText.text = "END OF DIALOGUE";
            Debug.Log("End of dialogue!");
            dialogueVariables.StopListening(currentStory); //if another exit function, put this there instead
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too many choices ("+currentChoices.Count +")for current UI.");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
            Debug.Log("CHOICE: " +choice.text +", IDX:" +choice.index);
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
