using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Light))]
public class FireLightable : MonoBehaviour
{
    GameObject toLight; // the object being lit
    GameObject lighter; // the object doing the lighting

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FireLightable>()) // all lightable objects must contain this script
        {
            Light lighterLighting = lighter.GetComponent<Light>();
            lighter = gameObject;
            toLight = other.gameObject;
            Light lightToLight = toLight.GetComponent<Light>();
            if (lighterLighting.intensity > 0 && lightToLight.intensity == 0)
            {
                lightToLight.intensity = lighterLighting.intensity; // whatever you are lighting will only be as bright as the object lighting it
            }
        }
    }


}
