using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOFFSwitch : MonoBehaviour, IButton
{
    public bool riddleSolved;
    public AudioSource PressedSFX;

    private Renderer _renderer;
    public bool IsOn { get; private set; } = false;

    private void Start() {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Color.red;
    }

    public void OnPressed()
    {
        if (riddleSolved)
            return;
        IsOn = !IsOn;

        if (IsOn) {
            PressedSFX.Play();
            _renderer.material.color = Color.green;
            transform.Translate(new Vector3(0, -0.1f, 0));
        } else {
            _renderer.material.color = Color.red;
            transform.Translate(new Vector3(0, 0.1f, 0));
        }
    }
}
