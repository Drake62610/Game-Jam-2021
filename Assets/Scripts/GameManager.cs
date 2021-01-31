using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevelId;
    public Animator transitionAnim;

    void Awake() {
        currentLevelId = 0;
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
        yield return new WaitForSeconds(1f);
        transitionAnim.ResetTrigger("end");
        transitionAnim.Play("transition_start");
    }
}
