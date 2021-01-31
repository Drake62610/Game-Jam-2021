using UnityEngine;

public class ButtonIlluminate : MonoBehaviour
{
    public GameObject plane;

    void OnTriggerEnter(Collider col) 
    {
        plane.SetActive(true);
    }

    void OnTriggerExit(Collider col) 
    {
       plane.SetActive(false);
    }
}
