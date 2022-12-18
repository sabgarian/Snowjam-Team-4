using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionActions : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        //LeanTween.cancelAll();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Restart()
    {
        //LeanTween.cancelAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
