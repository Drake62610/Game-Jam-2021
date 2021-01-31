using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStage : MonoBehaviour, ITriggerableObject
{

    public List<GameObject> smellsPaths;
    public GameObject orbPath;
    public GameObject senseOrb;

    public void Trigger()
    {
        foreach (var smellPath in smellsPaths)
        {
            smellPath.SetActive(false);
        }
        orbPath.SetActive(true);
        senseOrb.SetActive(true);
    }
}
