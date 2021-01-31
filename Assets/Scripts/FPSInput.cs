using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    public float speed = 4f;
    public float jumpForce = 5f;

    public bool isCrouched;

    public Camera playerCamera;
    public float maxButtonActivationDistance;

    private bool _inputJump;
    private bool _isGrounded;

    private Rigidbody _rb;

    void Start()
    {
        // _charController = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _inputJump = Input.GetButtonDown("Jump");

        Vector3 movement = new Vector3(moveHorizontal * speed * Time.deltaTime, 0, moveVertical * speed * Time.deltaTime);
        movement = Vector3.ClampMagnitude(movement, speed);
        transform.Translate(movement.x, 0, movement.z);

        if(IsGrounded() && _inputJump){
            _rb.AddForce(new Vector3( 0, jumpForce, 0), ForceMode.Impulse);
        }

        if (!isCrouched && Input.GetButtonDown("Crouch"))
        {
            isCrouched = true;
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.5f, transform.localPosition.z);
        }

        if (isCrouched & Input.GetButtonUp("Crouch"))
        {
            isCrouched = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            CheckActivateButton();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Platforms")
        {
            transform.parent = other.transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platforms")
        {
            transform.parent = null;
        }
    }

    void CheckActivateButton()
    {
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        int layer = 1 << LayerMask.NameToLayer("Default");

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, maxButtonActivationDistance, layer, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.gameObject.CompareTag("Button"))
            {
                IButton button = hit.collider.gameObject.GetComponent<IButton>();
                button.OnPressed();
            }
        }
    }

    void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platforms") {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platforms") {
            _isGrounded = false;
        }
    }
    public bool IsGrounded()
    {

        return _isGrounded;
        // Debug.Log(Physics.Raycast(transform.position, -Vector3.up, 1.0f));
        // return Physics.Raycast(transform.position, -Vector3.up, 1.0f);
    }
}
