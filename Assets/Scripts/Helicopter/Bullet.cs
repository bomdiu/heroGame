using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f; // Lượng sát thương mà viên đạn gây ra
    private Animator animator; // Thêm một tham chiếu đến Animator

    // Thêm biến âm thanh
    public AudioClip shootSound; // Âm thanh bắn súng
    public AudioClip movementSound; // Âm thanh di chuyển
    public AudioClip jumpSound; // Âm thanh nhảy
    private AudioSource audioSource; // AudioSource để phát âm thanh
    private bool isMoving = false;
    private Rigidbody2D rb; // Thêm tham chiếu đến Rigidbody2D để ngừng di chuyển


    void Start()
    {
        animator = GetComponent<Animator>(); // Lấy tham chiếu đến Animator của đối tượng
        rb = GetComponent<Rigidbody2D>(); // Lấy tham chiếu đến Rigidbody2D của đối tượng

        // Khởi tạo AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = true; // Lặp lại âm thanh di chuyển
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu va chạm với đối tượng có tag là "ground"
        if (other.CompareTag("ground"))
        {
            // Kích hoạt animation "Explosion"
            animator.SetBool("is_Exploding", true);

            // Dừng di chuyển của viên đạn
            rb.velocity = Vector2.zero;

            // Hủy đối tượng sau 0.5 giây
            Invoke("DestroyObject", 1f);

            // Phát âm thanh bắn súng
            PlayShootSound();
        }
        else if (other.CompareTag("Player"))
        {
            // Gây sát thương cho Player
            playerHealth playerHealthComponent = other.GetComponent<playerHealth>();
            if (playerHealthComponent != null)
            {
                playerHealthComponent.addDamage(damage);
            }

            // Kích hoạt animation "Explosion"
            animator.SetBool("is_Exploding", true);

            // Dừng di chuyển của viên đạn
            rb.velocity = Vector2.zero;

            // Hủy đối tượng sau 0.5 giây
            Invoke("DestroyObject", 1f);

            // Phát âm thanh bắn súng
            PlayShootSound();
        }
    }
    // Phương thức phát âm thanh bắn súng
    private void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
    void DestroyObject()
    {
        // Hủy đối tượng
        Destroy(gameObject);
    }
}
