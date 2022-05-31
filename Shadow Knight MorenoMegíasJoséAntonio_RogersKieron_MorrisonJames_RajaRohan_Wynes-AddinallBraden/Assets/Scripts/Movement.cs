using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    bool Isgrounded;

    public float jumpforce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    public float movementspeed = 5f;
    public float runspeed = 10f;
    float mx;
    float dashCoolDown = 0 ;

    public float speed = 20f;
    public float dashDistance = 10f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;

    public AudioSource audioSource;
    public AudioSource dashSound;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))                                           // jumping
        {
            if (Isgrounded)
            {
                Jump();
            }
        }

        Isgrounded = Physics2D.OverlapCircle(feet.position, 0.2f, groundLayers);

        if (Input.GetKey(KeyCode.LeftShift))
        {                                                                                // sprinting speed
            movementspeed = runspeed;
        }
        else
        {
            movementspeed = 5f;
        }

        if (dashCoolDown == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    StartCoroutine(Dash(-1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.2f;
                }

                lastKeyCode = KeyCode.A;
                dashSound.Play();
                dashCoolDown = 1000;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                {
                    StartCoroutine(Dash(1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.2f;
                }

                lastKeyCode = KeyCode.D;
                dashSound.Play();
                dashCoolDown = 1000;
            }
        }

        if (dashCoolDown > 0)
        {
            dashCoolDown -= 1;
        }
        
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            Vector2 movement = new Vector2(mx * movementspeed, rb.velocity.y);

            rb.velocity = movement;
        }
            

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
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(2f);
        isDashing = false;
        rb.gravityScale = gravity;

        if (gravity == 0)
        {
            rb.gravityScale = 2;
        }
    }
}
 

