using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPick : MonoBehaviour

{
    public void LoadLevel_1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel_3()
    {
        SceneManager.LoadScene("Level 3");
    }


    public void BackHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

