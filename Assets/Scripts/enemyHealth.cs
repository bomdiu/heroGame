using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    private Animator animator; // Thêm một tham chiếu đến Animator
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); // Lấy tham chiếu đến Animator của đối tượng
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("is_Destroyed", true); // Kích hoạt animation Smoke
            Invoke("makeDead", 1f);
        }
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;            
    }

    void makeDead()
    {
        Destroy (gameObject);
    }
}
