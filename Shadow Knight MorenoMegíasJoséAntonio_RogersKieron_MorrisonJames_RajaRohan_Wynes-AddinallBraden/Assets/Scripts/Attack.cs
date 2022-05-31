using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float StartTimeBtwattack;

    public Transform attackPos;
    public LayerMask whatisenemy;
    public float attackRange;
    public int damage;

    public AudioSource SwordSound;

   void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D[] enemiestodamange = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisenemy);
                for (int i = 0; i < enemiestodamange.Length; i++)
                {
                    enemiestodamange[i].GetComponent<healthcombat>().TakeDamage(damage);
                    
                }
                
                timeBtwAttack = StartTimeBtwattack;
                SwordSound.Play();
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, damage);

    }


}
