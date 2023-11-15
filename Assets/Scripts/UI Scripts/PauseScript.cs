using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    //private PlayerControls playerControls;
    public void MainMenu() {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;

    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void Restart() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }

}
