using System.Collections;
using UnityEngine;



public class CoinCollection : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           Destroy(this.gameObject);
        }

    }

}
