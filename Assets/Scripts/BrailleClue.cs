using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrailleClue : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            meshRenderer.enabled = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            meshRenderer.enabled = false;
        }
    }
}
