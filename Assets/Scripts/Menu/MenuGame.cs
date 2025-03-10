using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
    }

       public void SelectLevel()
    {
        SceneManager.LoadScene("Pick Level");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Home");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
