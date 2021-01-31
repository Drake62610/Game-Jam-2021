using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLevelId;
    public Animator transitionAnim;
    public GameObject endTextObject;

    private Text _endText;
    public bool canChangeScene;
    private static GameManager _instance;

    void Awake() {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            currentLevelId = 1;
    }

    void Start(){
        _endText = endTextObject.GetComponent<Text>();
    }

    void Update(){
        if(canChangeScene && Input.GetKeyDown(KeyCode.Space)){
            canChangeScene = false;
            endTextObject.SetActive(false);
            StartCoroutine(LoadScene());
        }
    }

    public void NextScene(string text){
        _endText.text = text;
        endTextObject.SetActive(true);
        canChangeScene = true;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<FPSInput>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().enabled = false;
    }

    IEnumerator LoadScene(){
        currentLevelId++;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(currentLevelId);   
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
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
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);

        transitionAnim.ResetTrigger("end");
        transitionAnim.Play("transition_start");
    }
}
