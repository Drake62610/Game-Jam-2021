using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    
    public List<ButtonScript> buttonsToActivate;
    public AudioSource wrongButtonsPressedAudioSource;
    public AudioSource rightButtonsPressedAudioSource;
    public AudioSource buttonPressedAudioSource;

    private List<ButtonScript> _activatedButtons = new List<ButtonScript>();

    public void AddActivatedButton(ButtonScript button)
    {
        _activatedButtons.Add(button);
        if (_activatedButtons.Count == buttonsToActivate.Count)
        {
            if (IsValidButtons())
            {
                rightButtonsPressedAudioSource.Play();
                IsPuzzleCompleted = true;
            }
            else
            {
                ResetAllPressedButtons();
            }
        }
    }

    public bool IsPuzzleCompleted { get; private set; } = false;

    public void PlayButtonPressedSound()
    {
        buttonPressedAudioSource.Play();
    }

    private bool IsValidButtons()
    {
        for (int i = 0; i < _activatedButtons.Count; i++)
        {
            if (_activatedButtons[i] != buttonsToActivate[i])
                return false;
        }
        return true;
    }

    private void ResetAllPressedButtons()
    {
        foreach (ButtonScript button in _activatedButtons)
        {
            button.resetButton();
        }
        _activatedButtons.Clear();
        wrongButtonsPressedAudioSource.Play();
    }
}
