using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused { get; private set; } = false;

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
        if (GameIsPaused)
        {
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
        }
    }
    
    void Paused()
    {
        //FPSInput.instance.enabled = false;
        GUI.enabled = false;
        UnlockCursor();
        pauseMenuUI.SetActive(true);
        ingameHUD.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        
        _camera.GetComponent<MouseLook>().enabled = false;
        _player.GetComponent<MouseLook>().enabled = false;
    }

    void Resume()
    {
        GUI.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        ingameHUD.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;
        
        _camera.GetComponent<MouseLook>().enabled = true;
        _player.GetComponent<MouseLook>().enabled = true;

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

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
