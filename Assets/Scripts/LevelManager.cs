using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject senseOrb;

    public void Trigger()
    {
        senseOrb.SetActive(true);
    }
}
