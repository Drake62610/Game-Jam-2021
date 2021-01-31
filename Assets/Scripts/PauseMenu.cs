using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject ingameHUD;
    public GameObject pauseMenuUI;
    public GameObject endgameUI;
    private GameObject _player;

    [SerializeField] Camera _camera;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (gameIsPaused)
        {
            _camera.GetComponent<MouseLook>().enabled = false;
            _player.GetComponent<MouseLook>().enabled = false;


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused();
            }
            _camera.GetComponent<MouseLook>().enabled = true;
            _player.GetComponent<MouseLook>().enabled = true;

        }
    }
    void Paused()
    {
        GUI.enabled = false;
        UnlockCursor();
        pauseMenuUI.SetActive(true);
        ingameHUD.SetActive(false);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    void Resume()
    {
        GUI.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        ingameHUD.SetActive(true);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        UnlockCursor();
        SceneManager.LoadScene("Menu");
    }

    public void TriggerEnd()
    {
        Time.timeScale = 0;
        ingameHUD.SetActive(false);
        endgameUI.SetActive(true);
        UnlockCursor();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
