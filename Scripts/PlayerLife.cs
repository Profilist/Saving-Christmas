using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anime;
    private Rigidbody2D rb;
    private Transform trans;

    private bool alive = true;

    [SerializeField] private AudioSource deathEFX;
    private void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }

    private void Update()
    {
         if (trans.position.y < -20 && alive)
         {
            Die();
            alive = false;
         } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathEFX.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anime.ResetTrigger("alive");
        anime.SetTrigger("death");
    }

    private void Restart()
    {
        trans.position = new Vector2(2, -1);
        rb.bodyType = RigidbodyType2D.Dynamic;
        anime.ResetTrigger("death");
        anime.SetTrigger("alive");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
