using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // your game scene index
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // works in editor
        Application.Quit();    // works in build
    }
}
