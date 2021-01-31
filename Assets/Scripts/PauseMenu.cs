using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused { get; private set; } = false;

    public GameObject ingameHUD;
    public GameObject pauseMenuUI;
    public GameObject endgameUI;
    
    private GameObject _player;
    private MouseLook _cameraMouseLookScript;
    private MouseLook _playerMouseLookScript;

    [SerializeField] private Camera _camera;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _cameraMouseLookScript = _camera.GetComponent<MouseLook>();
        _playerMouseLookScript = _player.GetComponent<MouseLook>();
        LockCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Paused();
        }
    }

    private void Paused()
    {
        //FPSInput.instance.enabled = false;
        GUI.enabled = false;
        UnlockCursor();
        pauseMenuUI.SetActive(true);
        ingameHUD.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        
        SetEnabledPlayerScripts(false);
    }

    private void Resume()
    {
        GUI.enabled = true;
        LockCursor();
        pauseMenuUI.SetActive(false);
        ingameHUD.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;
        
        SetEnabledPlayerScripts(true);
    }

    public void LoadMainMenu()
    {
        SetEnabledPlayerScripts(false);
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

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    private void SetEnabledPlayerScripts(bool scriptEnabled)
    {
        _cameraMouseLookScript.enabled = scriptEnabled;
        _playerMouseLookScript.enabled = scriptEnabled;
    }
}
