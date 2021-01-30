using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenseManager : MonoBehaviour
{
    public Image touchImage;
    public Image smellImage;
    public Image hearingImage;
    public Image sightImage;
    public AudioSource collectSenseSFX;

    private List<Sense> _collectedSenses = new List<Sense>();
    private enum Sense
    {
        Touch,
        Smell,
        Hearing,
        Sight,
    };

    public void OnSenseCollected(GameObject sense)
    {
        String senseName = sense.name;
        if (senseName.Equals("Touch Orb"))
            SetSenseCollected(Sense.Touch, touchImage);
        else if (senseName.Equals("Smell Orb"))
            SetSenseCollected(Sense.Smell, smellImage);
        else if (senseName.Equals("Hearing Orb"))
            SetSenseCollected(Sense.Hearing, hearingImage);
        else if (senseName.Equals("Sight Orb"))
            SetSenseCollected(Sense.Sight, sightImage);
        else
            Debug.Log("Unknown/Invalid sense: " + senseName);
    }

    private void SetSenseCollected(Sense sense, Image senseImage)
    {
        _collectedSenses.Add(sense);
        senseImage.color = new Color(255, 255, 255, 255);
        collectSenseSFX.Play();
    }
}
