using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] private string response;
    [SerializeField] private DialogueObj dialogueObject;

    public string ResponseText => response;

    public DialogueObj DialogueObj => dialogueObject;
}
