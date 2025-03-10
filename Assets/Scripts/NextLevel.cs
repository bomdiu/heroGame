using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string tenManChoi;
    public Animator animator; // Tham chiếu đến Animator

    public void LoadManChoiMoi()
    {
        SceneManager.LoadScene(tenManChoi);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("is_Touched", true); // Kích hoạt animation
            Invoke("LoadManChoiMoi", 5f); // Chờ 5 giây rồi chuyển scene
        }
    }
}
