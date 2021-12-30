using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();
            Invoke("FinishLevel", 2f);

            PlayerMovement movementScript = collision.gameObject.GetComponent<PlayerMovement>();
            StartCoroutine(disableMovement(movementScript));
        }
    }

    private IEnumerator disableMovement(PlayerMovement movementScript)
    {
        yield return new WaitUntil(movementScript.isGrounded);
        movementScript.anime.SetInteger("state", 0);
        movementScript.enabled = false;

    }
    private void FinishLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

