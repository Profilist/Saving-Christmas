using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool isScene = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                if (isScene)
                {
                    SceneTeleporter teleporter = currentTeleporter.GetComponent<SceneTeleporter>();
                    teleporter.TeleportSceneDestination();
                    //GameObject player = GameObject.FindWithTag("Player");
                    //player.GetComponent<Transform>().position = teleporter.GetSceneDestination().position;
                }
                else
                {
                    transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            isScene = false;
        }

        if (collision.CompareTag("Scene Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            isScene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                isScene = false;
            }
        }
    }
}
