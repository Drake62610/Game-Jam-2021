using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayMorse : MonoBehaviour, IButton
{
    private AudioSource _audioData;

    void Start()
    {
        _audioData = GetComponent<AudioSource>();
    }

    public void OnPressed()
    {
        if (!_audioData.isPlaying)
            _audioData.Play();
    }
}
