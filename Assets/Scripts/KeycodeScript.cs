using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeycodeScript : MonoBehaviour
{
    public string curPassword = "0340";
    public Text codeTextZone;
    public AudioSource successSFX;
    public AudioSource errorSFX;
    public GameObject riddleSymbol;
    
    private bool _riddleSolved;
    private string input;

    public GameObject _player;
    [SerializeField] Camera _camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivateKeypad();
        }
    }

    public void AddCodeInput(String number)
    {
        input += number;

        if (input == curPassword)
        {
            _riddleSolved = true;
            riddleSymbol.SetActive(true);
            successSFX.Play();
            DeactivateKeypad();
        }
        else if (input.Length >= curPassword.Length)
        {
            errorSFX.Play();
            DeactivateKeypad();
            input = "";
        }
        
        if (_riddleSolved)
        {
            Debug.Log("Solved");
        }
        codeTextZone.text = input;
    }

    public void ActivateKeypad()
    {
        this.gameObject.SetActive(true);
        SetPlayerScriptsStatus(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ManualExit()
    {
        input = "";
        codeTextZone.text = input;
        DeactivateKeypad();
    }

    public void DeactivateKeypad()
    {
        this.gameObject.SetActive(false);
        SetPlayerScriptsStatus(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void SetPlayerScriptsStatus(bool enabled)
    {
        // Disable Script
        _player.GetComponent<MouseLook>().enabled = enabled;
        _player.GetComponent<FPSInput>().enabled = enabled;
        _camera.GetComponent<MouseLook>().enabled = enabled;
    }

    public bool IsSolved()
    {
        return _riddleSolved;
    }
}