using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    [SerializeField] CanvasGroup Fade;
    public float fadeSpeed = 0.5f; // Tốc độ mờ

    bool fading = false;

    // Update is called once per frame
    void Update()
    {
        if (!fading)
        {
            Invoke("StartFadeOut", 2f);
        }
    }

    void StartFadeOut()
    {
        fading = true;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (Fade.alpha > 0)
        {
            Fade.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
