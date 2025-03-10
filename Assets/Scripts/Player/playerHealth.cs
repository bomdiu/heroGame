using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Để sử dụng UI
using UnityEngine.SceneManagement; // Để chuyển scene
using TMPro;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public string gameOverScene = "GameOverScene"; // Tên scene game over
    public PlayerHealthBar healthBar;
    public float healthPackValue = 1f; // Giá trị hồi phục của health pack

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu nhân vật rơi xuống vực
        if (transform.position.y < -20 && !isDead)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
            Invoke ("makeDead", 2f);
        }
    }
    
    public void addDamage(float damage)
    {
        if(damage <= 0 || isDead)
            return;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        isDead = true;
        // Chuyển sang game over scene
        SceneManager.LoadScene(gameOverScene);
        // Huỷ nhân vật
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shootable"))
        {
            currentHealth --;
            healthBar.SetHealth(currentHealth);
        }
                else if (collision.CompareTag("HealthPack"))
                {
                    addHealth(healthPackValue);
                    Destroy(collision.gameObject); // Huỷ health pack
                }
    }

    public void addHealth(float healthAmount)
    {
        if (isDead)
            return;

        currentHealth += healthAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }
}
