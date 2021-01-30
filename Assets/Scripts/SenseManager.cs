using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseManager : MonoBehaviour
{
    private List<Sense> _collectedSenses = new List<Sense>();
    private enum Sense
    {
        Sight,
        // ...
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onSenseCollected(GameObject sense)
    {
        String senseName = sense.name;
        if (senseName.Equals("Sight Orb"))
        {
            _collectedSenses.Add(Sense.Sight);
            Debug.Log(_collectedSenses);
        }
    }
}
