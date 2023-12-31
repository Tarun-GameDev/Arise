using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using SupersonicWisdomSDK;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject playingMenu;
    [SerializeField] GameObject levelFailedMenu;
    [SerializeField] GameObject levelCompletedMenu;
    [SerializeField] GameObject pauseMenu;
    public static bool gamePaused = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        playingMenu.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playingMenu.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void LevelFailed()
    {
        StartCoroutine(LevelFailedActive());
    }

    IEnumerator LevelFailedActive()
    {
        yield return new WaitForSeconds(2f);
        playingMenu.SetActive(false);
        levelFailedMenu.SetActive(true);
    }

    public void Restart()
    {
        if (gamePaused)
            ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelCompleted()
    {
        StartCoroutine(LevelCompleteActive());
    }

    IEnumerator LevelCompleteActive()
    {
        yield return new WaitForSeconds(2f);
        levelCompletedMenu.SetActive(true);
        playingMenu.SetActive(false);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
