using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRiddleManager : MonoBehaviour
{
    [SerializeField] OnOFFSwitch button_5;  // 1
    [SerializeField] OnOFFSwitch button_4;  // 0
    [SerializeField] OnOFFSwitch button_3;  // 1
    [SerializeField] OnOFFSwitch button_2;  // 0
    [SerializeField] OnOFFSwitch button_1;  // 1

    public GameObject riddleSymbol;
    public AudioSource successSFX;
    
    private bool isSolved;

    // Update is called once per frame
    void Update()
    {
        if (button_5.IsOn && button_3.IsOn && button_1.IsOn && !button_2.IsOn && !button_4.IsOn && !isSolved) {
            isSolved = true;
            riddleSymbol.SetActive(true);
            successSFX.Play();
        }
    }
}
