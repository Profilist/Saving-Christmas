using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interaction 
{
    [SerializeField] private DialogueObj dialogueObj;
    [SerializeField] private GameObject notice;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && collision.TryGetComponent(out PlayerMovement player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && collision.TryGetComponent(out PlayerMovement player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
        if(TryGetComponent(out GiveItem item)) {
            item.SpawnItem();
        }

        if (notice != null)
        {
            Destroy(notice);
        }
    }
    public void Interact(PlayerMovement player)
    {
        player.DialogueUI.ShowDialogue(dialogueObj);
    }
}
