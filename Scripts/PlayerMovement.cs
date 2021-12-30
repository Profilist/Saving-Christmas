using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anime;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Dialogue dialogueUI;

    public Dialogue DialogueUI => dialogueUI;

    public Interaction Interactable { get; set; }

    private float dirX = 0f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 12f;

    private enum MovementState { idle, running, jumping, falling };

    [SerializeField] private AudioSource jumpEFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (dialogueUI.isOpen)
        {
            anime.SetInteger("state", 0);
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.E) && dialogueUI.isOpen == false)
        {
            Interactable?.Interact(this);
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpEFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        anime.SetInteger("state", (int) state);
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
