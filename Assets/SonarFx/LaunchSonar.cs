using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class LaunchSonar : MonoBehaviour
{
    private SonarFx sonar;
    // Start is called before the first frame update
    void Start()
    {
        sonar = gameObject.GetComponent<SonarFx>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            sonar.enabled = true;
        }
        StartCoroutine(DisableRay());
    }

    private IEnumerator DisableRay()
    {
        yield return new WaitForSeconds(5f);
        sonar.enabled = false;
    }
}
