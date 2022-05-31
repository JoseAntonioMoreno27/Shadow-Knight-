using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDash : MonoBehaviour
{

    public float speed = 20f;

    bool isGrounded;
    float mx;
    float dashCoolDown;

    [SerializeField] Rigidbody2D rb;

    public float dashDistance = 10f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;

    public AudioSource audiosource;


    private void Update()
    {
        mx = Input.GetAxis("Horizontal");

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
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.A;
                audiosource.Play();
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
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.D;
                audiosource.Play();
                dashCoolDown = 1000;
            }
        }

        dashCoolDown -= 1;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);          
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
}

