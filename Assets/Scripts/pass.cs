using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(FireFlicker))]

public class Pass : MonoBehaviour
{
    GameObject toLight; // the object being lit
    GameObject lighter; // the object doing the lighting
    public GameObject flameObj; // the visual flame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pass>()) // all lightable objects must contain this script
        {
            lighter = gameObject;
            toLight = other.gameObject;
            Light lightToLight = toLight.GetComponent<Light>();
            Light lighterLighting = lighter.GetComponent<Light>();

            if (lighterLighting.intensity > 0 && lightToLight.intensity == 0)
            {
                toLight.GetComponent<Pass>().flameObj.SetActive(true);
                Debug.Log("inif");
                lightToLight.intensity = lighterLighting.intensity; // whatever you are lighting will only be as bright as the object lighting it
                toLight.GetComponent<FireFlicker>().currentIntense = lighter.GetComponent<FireFlicker>().currentIntense;
            }

        }
    }


}
