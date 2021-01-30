using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    public float fallingSpeed = 0.01f;
    public float endY;
    public bool isFalling = false;
    
    
    private Vector3 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        pos.y = endY;
        endPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            float step = fallingSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPosition, fallingSpeed);
        }
    }

    public void setIsFalling()
    {
        isFalling = true;
    }
}
