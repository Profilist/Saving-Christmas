using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject dialogueBox;

    public bool isOpen { get; private set; }

    private ResponseHandler responseHandler;
    private Typewriter typewriter;

    private void Start()
    {
        typewriter = GetComponent<Typewriter>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogue();
    }
    
    public void ShowDialogue(DialogueObj dialogueObj)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObj));
    }
    
    private IEnumerator StepThroughDialogue(DialogueObj dialogueObj)
    {
        for (int i = 0; i < dialogueObj.Dialogue.Length; i++)
        {
            string dialogue = dialogueObj.Dialogue[i];
            yield return typewriter.Run(dialogue, textLabel);

            if (i == dialogueObj.Dialogue.Length - 1 && dialogueObj.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObj.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObj.Responses);
        }
        else
        {
            CloseDialogue();
        }
    }

    private void CloseDialogue()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
