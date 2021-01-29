using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 4f;
    public float maxVelocityChange = 10.0f;
    public float jumpForce = 250f;

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

        Vector3 movement = new Vector3(moveHorizontal * speed, _rb.velocity.y, moveVertical * speed);
        movement = Vector3.ClampMagnitude(movement, speed);
        _rb.velocity = transform.TransformDirection(movement);
        // **
        // Calculate how fast we should be moving
		// Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		// targetVelocity = transform.TransformDirection(targetVelocity);
		// targetVelocity *= speed;
 
		// // Apply a force that attempts to reach our target velocity
		// Vector3 velocity = rb.velocity;
		// Vector3 velocityChange = (targetVelocity - velocity);
		// velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		// velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		// velocityChange.y = 0;
		// rb.AddForce(velocityChange, ForceMode.VelocityChange);
        // **

        // // Character Movement With Colisions
        // float deltaX = Input.GetAxis("Horizontal") * speed;
        // float deltaZ = Input.GetAxis("Vertical") * speed;
        // Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // movement = Vector3.ClampMagnitude(movement, speed);
        // // Gravity Force On PLayer
        // movement *= Time.deltaTime;
        // movement = transform.TransformDirection(movement);

        //_charController.Move(movement);
        if(isGrounded && _inputJump){
            _rb.AddForce(Vector3.up * jumpForce);
            Debug.Log("jump");
        }
    }

    void FixedUpdate() {
        //Jump
        
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
