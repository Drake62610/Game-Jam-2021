using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevelId;
    public Animator transitionAnim;
    public GameObject endText;

    void Awake() {
        currentLevelId = 1;
    }

    void Start(){

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            NextScene();
        }
    }

    public void NextScene(){
        StartCoroutine(LoadScene());
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
