using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletHit : MonoBehaviour
{
    public float damage = 1f; // Lượng sát thương mà viên đạn gây ra
    public float lifetime = 0.3f; // Thời gian tồn tại của viên đạn

    void Start()
    {
        // Hủy viên đạn sau một khoảng thời gian nhất định
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth playerHealthComponent = other.gameObject.GetComponent<playerHealth>();
            if (playerHealthComponent != null)
            {
                playerHealthComponent.addDamage(damage);
                Destroy(this.gameObject); // Hủy viên đạn sau khi va chạm
            }
        }
    }
}
