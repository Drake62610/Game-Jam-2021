using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySymbolOnTrigger : MonoBehaviour
{
    public GameObject riddleSymbol;
    public AudioSource successSFX;

    private bool isSolved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isSolved)
        {
            riddleSymbol.SetActive(true);
            successSFX.Play();
            isSolved = true;
        }
    }
}
