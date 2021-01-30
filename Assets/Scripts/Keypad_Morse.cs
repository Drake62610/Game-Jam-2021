using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad_Morse : MonoBehaviour
{

    public string curPassword = "0340";
    public string input;
    public bool onTrigger;
    public bool riddleSolved;
    public bool keypadScreen;
    public GameObject keypadGameObject;
    private GameObject _player;
    [SerializeField] Camera _camera;
 
    private float originalWidth = 1280.0f;  // define here the original resolution
    private float originalHeight = 720.0f; // you used to create the GUI contents 
    private Vector3 scale;
    
    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }
 
    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }
    void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(input == curPassword)
        {
            riddleSolved = true;
        }

        if(input.Length >= curPassword.Length)
        {
            keypadScreen = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Disable Script 
            _player.GetComponent<MouseLook>().enabled = true;
            _player.GetComponent<FPSInput>().enabled = true;
            _camera.GetComponent<MouseLook>().enabled = true;
        }

        if(riddleSolved)
        {
            Debug.Log("Solved");
        }
    }

    void OnGUI()
    {
        return;
        scale.x = Screen.width/originalWidth; // calculate hor scale
        scale.y = Screen.height/originalHeight; // calculate vert scale
        scale.z = 1;
        var svMat = GUI.matrix; // save current matrix
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

        if(!riddleSolved)
        {
            if(onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open keypad");
 
                if(Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    onTrigger = false;
                }
            }
 
            if(keypadScreen)
            {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                //Disable Script 
                _player.GetComponent<MouseLook>().enabled = false;
                _player.GetComponent<FPSInput>().enabled = false;
                _camera.GetComponent<MouseLook>().enabled = false;

                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);
 
                if(GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    input = input + "1";
                }
 
                if(GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    input = input + "2";
                }
 
                if(GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    input = input + "3";
                }
 
                if(GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input = input + "4";
                }
 
                if(GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input = input + "5";
                }
 
                if(GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input = input + "6";
                }
 
                if(GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    input = input + "7";
                }
 
                if(GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    input = input + "8";
                }
 
                if(GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    input = input + "9";
                }
 
                if(GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input = input + "0";
                }

                if(GUI.Button(new Rect(215, 350, 100, 100), "esc"))
                {
                    keypadScreen = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    //Disable Script 
                    _player.GetComponent<MouseLook>().enabled = true;
                    _camera.GetComponent<MouseLook>().enabled = true;
                    _player.GetComponent<FPSInput>().enabled = true;

                }
                
                GUI.matrix = svMat; // restore matrix
            }
        }
    }
}
