using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame3 : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Home");
    }
}
