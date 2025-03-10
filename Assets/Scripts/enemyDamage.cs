using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    float damageRate = 0.5f;
    float nextDamageTime = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            ApplyDamage(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            ApplyDamage(other);
        }
    }

    void ApplyDamage(Collider2D player)
    {
        playerHealth thePlayerHealth = player.GetComponent<playerHealth>();
        if (thePlayerHealth != null)
        {
            thePlayerHealth.addDamage(damage);
            nextDamageTime = Time.time + damageRate;
        }
    }
}
