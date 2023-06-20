using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GetThatKeyBack : MonoBehaviour
{
    public GameObject dakey;
    public GameObject BAT;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FireLightable>() && other.gameObject.GetComponent<Light>().intensity > 0 && !other.gameObject.GetComponent<LightSwitch>()) // is it a torch and not a lighter
        {
            dakey.GetComponent<XRGrabInteractable>().enabled = true; // allow key to be pickup
            dakey.GetComponent<Rigidbody>().useGravity = true; // use gravity on key
            dakey.transform.SetParent(null, true); // move parent to scene
            BAT.GetComponent<Animator>().SetInteger("batHit", 1); // transition bat from circling to escaping
        }
    }
}
