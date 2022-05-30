using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPause;
    public GameObject pauseGameMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void PauseGame()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
