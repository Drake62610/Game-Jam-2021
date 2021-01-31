using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseCollector : MonoBehaviour
{
    public SenseManager senseManager;
    public string endText;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        senseManager = gameManager.GetComponent<SenseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sense"))
        {
            senseManager.OnSenseCollected(other.gameObject);
            Destroy(other.gameObject);
            gameManager.NextScene(endText);
        }
    }
}
