using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/UI/OpenMenu", gameObject);
            if (GameIsPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        Destroy(GameObject.FindGameObjectWithTag("GM"));
        Resume();
        SceneManager.LoadScene("1-1 A Clockwork");
    }

    public void LoadMenu()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/UI/OpenMenu", gameObject);
        SceneManager.LoadScene("Menu");
        Resume();
        Destroy(GameObject.FindGameObjectWithTag("GM"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
