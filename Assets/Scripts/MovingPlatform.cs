using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] Waypoints;
    public enum MovingMode
    {
        Horizontal = 0,
        Vertical = 1,
    }
    public MovingMode mode = MovingMode.Vertical;
    public float speed = 2;

    public int CurrentPoint = 0;


    void FixedUpdate()
    {
        if (mode == MovingMode.Vertical)
        {
            if (transform.position.y != Waypoints[CurrentPoint].transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
            }

            if (transform.position.y == Waypoints[CurrentPoint].transform.position.y)
            {
                CurrentPoint += 1;
            }
            if (CurrentPoint >= Waypoints.Length)
            {
                CurrentPoint = 0;
            };
        }
        else
        {
            if (transform.position.z != Waypoints[CurrentPoint].transform.position.z)
            {
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
            }

            if (transform.position.z == Waypoints[CurrentPoint].transform.position.z)
            {
                CurrentPoint += 1;
            }
            if (CurrentPoint >= Waypoints.Length)
            {
                CurrentPoint = 0;
            };
        }


    }
}
