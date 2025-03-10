using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonHealth : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;
    
    // Khai báo sự kiện khi Cannon bị hủy
    public delegate void CannonDestroyedAction();
    public event CannonDestroyedAction OnCannonDestroyed;

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
        // Kiểm tra khi máu bằng 0
        if (currentHealth <= 0)
        {
            // Kích hoạt animation "Cannon Explosion"
            animator.SetBool("is_Destroyed", true);

            Invoke("DestroyObject", 0.5f);

            // Thông báo cho DestroyBossAfterHelicopterDeath biết rằng Helicopter đã bị hủy
            OnCannonDestroyed?.Invoke();
        }
    }

    void DestroyObject()
    {
        // Hủy đối tượng
        Destroy(gameObject);
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
    }
}
