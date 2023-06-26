using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchOut : MonoBehaviour
{
    private GameObject rain;
    public GameObject flameObj;
    public GameObject torchtip;
    GameObject torch;

    private void OnTriggerEnter(Collider other)
    {
        rain = gameObject;
        torchtip = other.gameObject;
        if (torch.GetComponent<FireLightable>().flameObj.activeSelf == true)
        {
            other.GetComponent< FireLightable > ().flameObj.SetActive(false);
            Light torchtip = other.GetComponent<Light>();
            torchtip.intensity = 0;

        }
    }
}