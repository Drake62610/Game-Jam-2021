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

    private Text endText;
    public bool canChangeScene;

    void Awake() {
        currentLevelId = 1;
    }

    void Start(){
        endText = endTextObject.GetComponent<Text>();
    }

    void Update(){
        if(canChangeScene && Input.GetKeyDown(KeyCode.Space)){
            canChangeScene = false;
            endTextObject.SetActive(false);
            StartCoroutine(LoadScene());
        }
    }

    public void NextScene(string text){
        endText.text = text;
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
