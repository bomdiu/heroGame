using System.Collections;
using UnityEngine;

public class HelicopterHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    private Animator animator; // Thêm một tham chiếu đến Animator

    public HealthBar healthBar;

    // Khai báo sự kiện khi Helicopter bị hủy
    public delegate void HelicopterDestroyedAction();
    public event HelicopterDestroyedAction OnHelicopterDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>(); // Lấy tham chiếu đến Animator của đối tượng
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra khi máu bằng 0
        if (currentHealth <= 0)
        {
            // Kích hoạt animation "Helicopter Explosion"
            animator.SetBool("is_Destroyed", true);

            // Thông báo cho DestroyBossAfterHelicopterDeath biết rằng Helicopter đã bị hủy
            OnHelicopterDestroyed?.Invoke();
        }
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
