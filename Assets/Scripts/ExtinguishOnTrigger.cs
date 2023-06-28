using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<FireLightable>())
        {
            other.GetComponentInChildren<FireLightable>().ExtFire();
        }
    }
}
