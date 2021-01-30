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

    private bool isSolved;

    // Update is called once per frame
    void Update()
    {
        if (button_5.isOn && button_3.isOn && button_1.isOn && !button_2.isOn && !button_4.isOn) {
            isSolved = true;
            Debug.Log("Wow solved incredible");
        }
    }
}
