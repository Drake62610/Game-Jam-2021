using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 5f;

    public bool isGrounded;
    public bool isCrouched;
    private bool _inputJump;

    private Rigidbody _rb;
  
    void Start()
    {
        // _charController = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {       
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        _inputJump = Input.GetButtonDown("Jump");

        Vector3 movement = new Vector3(moveHorizontal * speed * Time.deltaTime, 0, moveVertical * speed * Time.deltaTime);
        movement = Vector3.ClampMagnitude(movement, speed);
        transform.Translate(movement.x, 0, movement.z);

        if(isGrounded && _inputJump){
            _rb.AddForce(new Vector3( 0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }
}
