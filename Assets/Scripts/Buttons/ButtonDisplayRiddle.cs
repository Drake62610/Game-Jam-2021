using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisplayRiddle : MonoBehaviour, IButton
{
    public GameObject riddleSymbol;
    public AudioSource successSFX;
    private bool _isSolved = false;

    public void OnPressed()
    {
        if (!_isSolved)
        {
            _isSolved = true;
            successSFX.Play();
            riddleSymbol.SetActive(true);
        }
    }
}
