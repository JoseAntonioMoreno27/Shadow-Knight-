using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthcombat : MonoBehaviour
{
    public int health;
    public Slider healthbar;

    public static healthcombat instance;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        healthbar.value = health;
    }

    public void Start()
    {
        healthbar.maxValue = health;
        healthbar.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.value = health;
        Debug.Log("Damage taken");
    }
}
