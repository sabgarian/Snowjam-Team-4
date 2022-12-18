using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;
    [SerializeField] private GameObject pauseMenu;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //Will use old input manager for now to keep consistent
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            } else
            {
                Pause();
            }
            paused = !paused;
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    void Resume()
    {
        pauseMenu.GetComponent<OpenUI>().closeUI();
        Time.timeScale = 1f;
    }
}
