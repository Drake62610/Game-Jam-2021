using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroduScript : MonoBehaviour
{
    public GameObject[] textList;

    private int currentId;

    // Start is called before the first frame update
    void Start()
    {
        currentId = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            nextText();
        }
    }

    void nextText(){
        textList[currentId].SetActive(false);
        currentId++;

        if(currentId < textList.Length){
            textList[currentId].SetActive(true);
        } else {
            SceneManager.LoadScene(2);
        }
    }
}
