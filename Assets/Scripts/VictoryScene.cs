using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public string tenManChoi;
    public Animator animator; // Tham chiếu đến Animator

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Lấy component DestroyBoss từ đối tượng va chạm
        DestroyBoss destroyBoss = collision.GetComponent<DestroyBoss>();

        // Kiểm tra nếu đối tượng va chạm có tag là "Player" và biến helicopterDestroyed của DestroyBoss là true
        if (collision.CompareTag("Player") && destroyBoss != null && destroyBoss.helicopterDestroyed)
        {
            animator.SetBool("is_Touched", true); // Kích hoạt animation
            Invoke("LoadManChoiMoi", 5f); // Chờ 5 giây rồi chuyển scene
        }
    }

    public void LoadManChoiMoi()
    {
        SceneManager.LoadScene(tenManChoi);
    }
}
