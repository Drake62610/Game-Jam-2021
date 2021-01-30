using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSense : MonoBehaviour
{
    public float footDistance = 0f;
    public float footprintDistanceMin = 1f;

    public float handDistance = 0f;
    public float handprintDistanceMin = 1f;

    public GameObject leftFoot;
    public GameObject rightFoot;

    public GameObject leftPrintPrefab;
    public GameObject rightPrintPrefab;
    public GameObject leftHandPrefab;
    public GameObject rightHandPrefab;

    public bool leftHandTouching;
    public bool rightHandTouching;

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
        CreateLeftFootPrint();
        CreateRightFootPrint();
    }

    void Update() {
        Debug.DrawRay(transform.position, transform.forward * 2f);

        // RaycastHit hit;
        //  if (Physics.Raycast(transform.position + new Vector3(0f, 0.4f, 0f), transform.forward, out hit))
        //  {
        //     if(Vector3.Distance(player.transform.position, hit.point) < 2.5f){
        //         if(leftHandTouching && rightHandTouching){
        //             CreateHandPrint(hit,false);
        //         }
        //     }        
        //  }
    }

    void FixedUpdate()
    {
        if(fpsInput.IsGrounded()){
            footDistance += Vector3.Distance(transform.position, oldPos);
            handDistance += Vector3.Distance(transform.position, oldPos);
            oldPos = transform.position;
        }

        if(footDistance >= footprintDistanceMin && fpsInput.IsGrounded()){
            footDistance = 0f;
            if(nextIsRight){
                nextIsRight = false;
                CreateRightFootPrint();
            } else {
                nextIsRight = true;
                CreateLeftFootPrint();
            }
        }
    }

    public void CreateLeftFootPrint(){
        Instantiate(leftPrintPrefab, leftFoot.transform.position, leftFoot.transform.rotation);
        footDistance = 0f;
    }

     public void CreateRightFootPrint(){
        Instantiate(rightPrintPrefab, rightFoot.transform.position, rightFoot.transform.rotation);
        footDistance = 0f;
    }

    public void CreateHandPrint(RaycastHit hit, bool isLeftHand, bool rotation = true){
        if(handDistance >= handprintDistanceMin){
            GameObject hand = new GameObject();

            if(isLeftHand) {
                hand = Instantiate(leftHandPrefab, hit.point, Quaternion.identity);
            } else {
                hand = Instantiate(rightHandPrefab, hit.point, Quaternion.identity);
            }

            if(rotation){
                Vector3 newRotation = (Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation).eulerAngles;
                hand.transform.rotation = Quaternion.Euler(hand.transform.rotation.x, newRotation.y, hand.transform.rotation.z);
            }
            
            handDistance = 0f;
        }
    }
}
