using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject mainUI;
    public GameObject creditsUI;

    public void TogglePause()
    {
        if (GameIsPaused)
            Play();
        else
            Pause();
    }

    public void ShowCredits()
    {
        mainUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void ShowMainMenu()
    {
        creditsUI.SetActive(false);
        mainUI.SetActive(true);
    }

    void Play()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        ShowMainMenu();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
