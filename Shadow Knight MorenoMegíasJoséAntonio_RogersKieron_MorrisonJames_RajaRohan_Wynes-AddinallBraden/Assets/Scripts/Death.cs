using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            Respawn();
        }
    }
}
