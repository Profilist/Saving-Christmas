using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private Dialogue dialogueUI;

    List<GameObject> responseButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<Dialogue>();
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0f;

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnResponse(response));

            responseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in responseButtons)
        {
            Destroy(button);
        }
        responseButtons.Clear();

        dialogueUI.ShowDialogue(response.DialogueObj);
    }
}
