using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(FireFlicker))]

public class FireLightable : MonoBehaviour
{
    GameObject toLight; // the object being lit
    GameObject lighter; // the object doing the lighting
    public GameObject flameObj; // the visual flame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FireLightable>()) // all lightable objects must contain this script
        {
            lighter = gameObject;
            toLight = other.gameObject;
            Light lightToLight = toLight.GetComponent<Light>();
            Light lighterLighting = lighter.GetComponent<Light>();

            if (lighterLighting.intensity > 0 && lightToLight.intensity == 0)
            {
                toLight.GetComponent<FireLightable>().flameObj.SetActive(true);
                Debug.Log("inif");
                lightToLight.intensity = lighterLighting.intensity; // whatever you are lighting will only be as bright as the object lighting it
                toLight.GetComponent<FireFlicker>().currentIntense = lighter.GetComponent<FireFlicker>().currentIntense;
            }
        }
    }

    public void LightFire() // light fire from script without collision
    {
        toLight = gameObject;
        Light lightToLight = toLight.GetComponent<Light>();
        flameObj.SetActive(true);
        lightToLight.intensity = 1;
    }

    public void ExtFire() // extinguish fire from script without collision
    {
        toLight = gameObject;
        Light lightToLight = toLight.GetComponent<Light>();
        flameObj.SetActive(false);
        lightToLight.intensity = 0;
    }
}
