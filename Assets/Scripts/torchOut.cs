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
        torch = other.gameObject;
        if (torch.GetComponent<FireLightable>().flameObj.activeSelf == true)
        {
            torch.GetComponent< FireLightable > ().flameObj.SetActive(false);

        }
    }
}