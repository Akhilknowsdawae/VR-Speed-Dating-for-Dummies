using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        currentStory = new Story(inkJSON.text);
        dialoguePanel.SetActive(true);
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
}
