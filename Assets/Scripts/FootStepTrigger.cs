using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepTrigger : MonoBehaviour
{

    private AudioSource _footsteps;
    // Start is called before the first frame update
    public bool IsMoving;
    private void Start()
    {
        _footsteps = GetComponent<AudioSource>();
    }

    void Update()
    {

        // if (Input.GetAxis("Vertical") < 0) IsMoving = true; 
        // else IsMoving = false;

        // if (IsMoving && !_footsteps.isPlaying) _footsteps.Play(); 
        // if (!IsMoving) _footsteps.Stop(); 
        // void OnCollisionEnter(Collision other)
        // {
        //     if (other.gameObject.tag == "Player" && (Input.GetAxis("Vertical") < 0) {
        //         if (!_footsteps.isPlaying)
        //         {
        //             _footsteps.Play(0);
        //         }
        //         else
        //             _footsteps.Stop();
        //     }
        // }
    }
}
