using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 0.5f;
    public float sensitivityVer = 0.5f;

    public float verMin = -45.0f;
    public float verMax = 45.0f;

    private float _rotationX = 0;
    private float _rotationY = 0;

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseY) {
            // Compute X axe rotation
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, verMin, verMax);

            // Compute Y axe rotation
            _rotationY = this.transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, verMin, verMax);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            _rotationY =  transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
