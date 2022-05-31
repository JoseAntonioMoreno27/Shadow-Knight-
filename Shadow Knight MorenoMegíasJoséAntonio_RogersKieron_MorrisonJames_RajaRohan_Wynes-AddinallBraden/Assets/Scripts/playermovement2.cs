using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovement2 : MonoBehaviour
{
    public float movementspeed =5f;
    public float runspeed = 20f;
    public Rigidbody2D rb;
    public Slider StaminaBar;

    bool Isgrounded;
    private bool canJump;
    private bool CanSprint;
    public float jumpforce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    
    float mx;

    public float speed = 20f;
    public float dashDistance = 10f;
    float dashCoolDown;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;

    public AudioSource audioSource;
    public AudioSource dashSound;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && StaminaBar.value > 50)
            
        {
            if (Isgrounded)
            {
                Staminabar.instance.UseStamina(50);
                Jump();
            }
            else
            {
                canJump = false;
            }

        }


        if (Input.GetKey(KeyCode.LeftShift) && StaminaBar.value > 5)
        {
            Staminabar.instance.UseStamina(5);
            movementspeed = runspeed;
        }                                                                                                               //sprinting move speed
        else
        {
            CanSprint = false;
            movementspeed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A && StaminaBar.value > 600)
            {
                Staminabar.instance.UseStamina(600);
                StartCoroutine(Dash(-1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.2f;
            }

            lastKeyCode = KeyCode.A;
            
            dashCoolDown = 1000;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D && StaminaBar.value > 500)
            {
                Staminabar.instance.UseStamina(500);
                StartCoroutine(Dash(1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.2f;
            }

            lastKeyCode = KeyCode.D;
            
            dashCoolDown = 1000;
        }

    }

    private void FixedUpdate()
    {
        if (isDashing == true)
        {
            Vector2 movement = new Vector2(mx * speed, rb.velocity.y);

            rb.velocity = movement;
        }

        else
        {
            Vector2 movement = new Vector2(mx * movementspeed, rb.velocity.y);

            rb.velocity = movement;
        }

        Isgrounded = Physics2D.OverlapCircle(feet.position, 0.2f, groundLayers);                                         //check for ground before can jump
    }
    
    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpforce);

        rb.velocity = movement;
        audioSource.Play();
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        dashSound.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.1f);
        isDashing = false;
        rb.gravityScale = gravity;

        if (gravity == 0)
        {
            rb.gravityScale = 2;
        }
    }

}
