using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOFFSwitch : MonoBehaviour
{

    public bool isOn = false;
    public bool onTrigger;
    public bool riddleSolved;
    private Renderer _renderer;

    private void Start() {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Color.red;
    }

   void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }
 
    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }
    void Update()
    {
    }
 
    void OnGUI()
    {
        if(!riddleSolved)
        {
            if(onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open keypad");
 
                if(Input.GetKeyDown(KeyCode.E))
                {
                    onTrigger = false;
                    isOn = !isOn;

                    if (isOn) {
                        _renderer.material.color = Color.green;
                    } else {
                        _renderer.material.color = Color.red;
                    }

                }

                Debug.Log(isOn);
            }
        }
    }
}
