using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame2 : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Home");
    }
}
