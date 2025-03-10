using System.Collections;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{
    private HelicopterHealth helicopterHealth;
    public bool helicopterDestroyed = false;
    public static bool bossIsDead = false; 

    void Start()
    {
        // Tìm đối tượng con chứa "HelicopterHealth" trong đối tượng Boss
        helicopterHealth = GetComponentInChildren<HelicopterHealth>();

        if (helicopterHealth != null)
        {
            // Đăng ký sự kiện khi Helicopter bị phá hủy
            helicopterHealth.OnHelicopterDestroyed += DestroyBossAfterDelay;
        }
    }

    private void DestroyBossAfterDelay()
    {
        if (!helicopterDestroyed)
        {
            helicopterDestroyed = true;

            // Hủy đăng ký sự kiện
            helicopterHealth.OnHelicopterDestroyed -= DestroyBossAfterDelay;

            // Sử dụng Invoke để hủy đối tượng Boss sau 5 giây
            Invoke("DestroyBossObject", 5f);
        }
    }

    private void DestroyBossObject()
    {
        bossIsDead = true;
        // Hủy đối tượng Boss
        Destroy(gameObject);
    }
}
