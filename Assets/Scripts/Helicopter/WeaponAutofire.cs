using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutofire : MonoBehaviour
{
    public GameObject bullet;
    public float reloadSpeed = 1;
    public float bulletSpeed = 10f;
    public float firingRange = 10f;
    private float reloadTimer = 0;
    private bool canFire = true;
    private Transform player; // Tham chiếu đến đối tượng người chơi


    // Thêm biến âm thanh
    public AudioClip shootSound; // Âm thanh bắn súng
    public AudioClip movementSound; // Âm thanh di chuyển
    public AudioClip jumpSound; // Âm thanh nhảy
    private AudioSource audioSource; // AudioSource để phát âm thanh
    private bool isMoving = false;
    void Start()
    {
        // Tìm đối tượng người chơi trong Scene
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Đăng ký sự kiện từ đối tượng Boss
        HelicopterHealth bossHealth = FindObjectOfType<HelicopterHealth>(); // Tìm đối tượng HelicopterHealth trong Scene
        if (bossHealth != null)
        {
            bossHealth.OnHelicopterDestroyed += StopFiring; // Đăng ký sự kiện dừng bắn khi Boss bị hủy
        }

        // Khởi tạo AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = true; // Lặp lại âm thanh di chuyển
    }

    void Update()
    {
        if (canFire && IsPlayerInRange())
        {
            reloadTimer += Time.deltaTime;

            if (reloadTimer >= reloadSpeed)
            {
                reloadTimer = 0;
                Fire();
                // Phát âm thanh bắn súng
                PlayShootSound();
            }
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
        // Kiểm tra xem người chơi có trong phạm vi bắn không
        private bool IsPlayerInRange()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            return distance <= firingRange;
        }
        return false;
    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }
    // Phương thức dừng bắn
    private void StopFiring()
    {
        canFire = false; // Đặt biến canFire thành false để ngăn súng tiếp tục bắn
    }
    
   
}
    