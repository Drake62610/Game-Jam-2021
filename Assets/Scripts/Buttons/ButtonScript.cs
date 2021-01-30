using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour, IButton
{
    public Color activatedColor;
    private Color _deactivatedColor;
    public ButtonsManager buttonsManager;
    
    private bool _isActivated = false;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _deactivatedColor = _renderer.material.color;
    }

    public void OnPressed()
    {
        if (!_isActivated && !buttonsManager.IsPuzzleCompleted)
        {
            _renderer.material.SetColor("_Color", activatedColor);
            _isActivated = true;
            buttonsManager.AddActivatedButton(this);
            buttonsManager.PlayButtonPressedSound();
        }
    }

    public void resetButton()
    {
        _isActivated = false;
        _renderer.material.SetColor("_Color", _deactivatedColor);
    }
}
