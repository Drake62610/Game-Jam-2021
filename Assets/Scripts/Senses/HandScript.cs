using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public bool isLeftHand;

    private GameObject player;
    private TouchSense touchSense;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        touchSense = player.GetComponent<TouchSense>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall"){
            if(isLeftHand){
                touchSense.leftHandTouching = true;
            } else {
                touchSense.rightHandTouching = true;
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.tag == "Wall"){
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, -5, QueryTriggerInteraction.Ignore))
            {
                if(Vector3.Distance(player.transform.position, hit.point) < 2f){
                    touchSense.CreateHandPrint(hit,isLeftHand);
                }        
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Wall"){
            if(isLeftHand){
                touchSense.leftHandTouching = false;
            } else {
                touchSense.rightHandTouching = false;
            }
        }
    }
}
