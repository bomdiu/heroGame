using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
public float moveSpeed = 2.0f; // Tốc độ di chuyển của enemy
public float moveDistance = 2.0f; // Khoảng cách di chuyển theo trục x
public Transform firePoint; // Vị trí bắn đạn
public Animator animator; // Animator của enemy
private float originalX; // Vị trí ban đầu theo trục x
private bool movingRight = false; // Kiểm soát hướng di chuyển

public GameObject bulletPrefab; // Prefab đạn
public float bulletForce = 20f; // Lực đẩy của đạn
public float fireRate = 1f; // Tần suất bắn đạn

private float nextFireTime = 0f; // Thời điểm bắn đạn tiếp theo

// Start is called before the first frame update
void Start()
{
    originalX = transform.position.x; // Lưu lại vị trí ban đầu theo trục x
}

// Update is called once per frame
void Update()
{
    Move();
    HandleShooting();
}

void Move()
{
    if (movingRight)
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (transform.position.x >= originalX + moveDistance)
        {
            Flip();
            movingRight = false;
        }
    }
    else
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (transform.position.x <= originalX - moveDistance)
        {
            Flip();
            movingRight = true;
        }
    }

}

void Flip()
{
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
}

void HandleShooting()
{
    if (Time.time >= nextFireTime)
    {
        Shoot();
        nextFireTime = Time.time + 1f / fireRate;
    }
}

void Shoot()
{
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    // Xác định hướng quay của enemy
    Vector3 enemyScale = transform.localScale;

    // Thiết lập hướng di chuyển của đạn dựa trên hướng quay của enemy
    if (enemyScale.x > 0) // enemy đang quay về phía phải
    {
        rb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
    else // enemy đang quay về phía trái
    {
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
}