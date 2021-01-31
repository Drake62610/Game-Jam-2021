using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKeypad : MonoBehaviour, IButton
{
    public KeycodeScript keypadScript;
    public PauseMenu pauseMenu;

    public void OnPressed()
    {
        if (!keypadScript.IsSolved() && !pauseMenu.GameIsPaused)
        {
            keypadScript.ActivateKeypad();
        }
    }
}
