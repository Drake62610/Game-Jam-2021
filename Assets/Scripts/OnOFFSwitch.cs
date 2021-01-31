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
 
                if(Input.GetButtonDown("Fire1"))
                {
                    onTrigger = false;
                    isOn = !isOn;

                    if (isOn) {
                        _renderer.material.color = Color.green;
                        transform.Translate(new Vector3(0, -0.1f, 0));
                    } else {
                        _renderer.material.color = Color.red;
                        transform.Translate(new Vector3(0, 0.1f, 0));
                    }

                }
            }
        }
    }
}
