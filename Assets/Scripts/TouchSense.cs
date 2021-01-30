using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSense : MonoBehaviour
{
    public float distance = 0f;
    public float footprintDistance = 1f;

    public GameObject leftFoot;
    public GameObject rightFoot;

    public GameObject leftPrintPrefab;
    public GameObject rightPrintPrefab;

    private bool nextIsRight;

    private Vector3 oldPos;
    private GameObject player;
    private FPSInput fpsInput;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        fpsInput = player.GetComponent<FPSInput>();
        CreateLeftPrint();
        CreateRightPrint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fpsInput.IsGrounded()){
            distance += Vector3.Distance(transform.position, oldPos);
            oldPos = transform.position;
        }

        if(distance >= footprintDistance){
            distance = 0f;
            if(nextIsRight){
                nextIsRight = false;
                CreateRightPrint();
            } else {
                nextIsRight = true;
                CreateLeftPrint();
            }
        }
    }

    public void CreateLeftPrint(){
        Instantiate(leftPrintPrefab, leftFoot.transform.position, leftFoot.transform.rotation);
        distance = 0f;
    }

     public void CreateRightPrint(){
        Instantiate(rightPrintPrefab, rightFoot.transform.position, rightFoot.transform.rotation);
        distance = 0f;
    }
}
