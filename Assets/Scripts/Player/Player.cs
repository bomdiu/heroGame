using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed; // Khai báo biến tốc độ
    public float jumpHeight; // Khai báo biến nhảy

    bool facingRight; // Kiểm tra quay mặt
    bool grounded; // Kiểm tra mặt đất để nhảy

    // Khai báo để bắn
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    Rigidbody2D myBody;
    Animator myAnim;

    // Thêm biến leo trèo
    public float climbSpeed = 3f;
    private bool isClimbing = false;
    private bool canClimb = false;
    private Rigidbody2D rb;

    // Thêm biến âm thanh
    public AudioClip shootSound; // Âm thanh bắn súng
    public AudioClip movementSound; // Âm thanh di chuyển
    public AudioClip jumpSound; // Âm thanh nhảy
    private AudioSource audioSource; // AudioSource để phát âm thanh
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        facingRight = true;

        // Khởi tạo AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = true; // Lặp lại âm thanh di chuyển
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float climb = Input.GetAxis("Vertical");

        myAnim.SetFloat("speed", Mathf.Abs(move));

        if (isClimbing)
        {
            rb.velocity = new Vector2(move * maxSpeed, climb * climbSpeed);
            rb.gravityScale = 0;
            myAnim.SetBool("isClimbing", true);

            // Kiểm tra nếu không có input, giữ vận tốc y của nhân vật bằng 0
            if (move == 0 && climb == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
        else
        {
            rb.gravityScale = 2;
            myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
            myAnim.SetBool("isClimbing", false);
        }

        // Kiểm tra quay mặt
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        // Gán nút nhảy
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (grounded)
            {
                grounded = false;
                myAnim.SetBool("isJumping", true);
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
                // Phát âm thanh nhảy
                PlayJumpSound();
            }
        }

        // Chức năng bắn từ bàn phím
        if (Input.GetAxisRaw("Fire1") > 0)
            fireBullet();

        // Cập nhật âm thanh di chuyển
        if (Mathf.Abs(move) > 0 || Mathf.Abs(climb) > 0)
        {
            if (!isMoving)
            {
                audioSource.clip = movementSound;
                audioSource.Play();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                audioSource.Stop();
                isMoving = false;
            }
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = true;
            myAnim.SetBool("isJumping", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            canClimb = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            canClimb = false;
            isClimbing = false;
        }
    }

    // Gán nút leo
    void Update()
    {
        if (canClimb && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            isClimbing = true;
        }
        else if (canClimb && !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            isClimbing = false;
        }

        // Chức năng bắn đạn khi nhấn phím Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireBullet();
        }
    }

    // Chức năng bắn
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(180, 180, 180)));
            }

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

    // Phương thức phát âm thanh nhảy
    private void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
