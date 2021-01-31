using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKeypad : MonoBehaviour, IButton
{
    public KeycodeScript keypadScript;

    public void OnPressed()
    {
        if (!keypadScript.IsSolved())
        {
            keypadScript.ActivateKeypad();
        }
    }
}
