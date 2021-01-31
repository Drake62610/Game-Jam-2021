using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWarp : MonoBehaviour
{

    public Vector3 playerSpawn;

    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {

            other.gameObject.transform.position = playerSpawn;
        }
    }
}
