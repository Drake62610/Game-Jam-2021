using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Morse : MonoBehaviour
{
    private AudioSource _audioData;
    public bool onTrigger;

    void Start()
    {
        _audioData = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

    void OnGUI()
    {
        if (onTrigger)
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to play sound");

            if (Input.GetKeyDown(KeyCode.E))
            {
                _audioData.Play(0);
                onTrigger = false;
            }
        }
    }


}
