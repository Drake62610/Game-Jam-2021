using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
   public static bool gameIsPaused = false;

   public GameObject ingameHUD;
   public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        GUI.enabled = false;
        pauseMenuUI.SetActive(true);
        ingameHUD.SetActive(false);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    void Resume()
    {
        GUI.enabled = true;
        pauseMenuUI.SetActive(false);
        ingameHUD.SetActive(true);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
