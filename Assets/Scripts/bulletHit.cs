using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    public float weaponDamage;

    projectile myPC;

    void Awake()
    {
        myPC = GetComponentInParent<projectile>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            myPC.removeForce();
            Destroy(gameObject);
            if(other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage (weaponDamage);
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("boss"))
            {
                HelicopterHealth hurtBoss = other.gameObject.GetComponent<HelicopterHealth>();
                hurtBoss.addDamage (weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            myPC.removeForce();
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("boss"))
            {
                HelicopterHealth hurtBoss = other.gameObject.GetComponent<HelicopterHealth>();
                hurtBoss.addDamage (weaponDamage);
            }
        }   
    }
}
