using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class FireDestroy : MonoBehaviour
{
    private GameObject barrier;
    public GameObject flameObj;
    GameObject torch;
   
    private void OnTriggerEnter(Collider other)
    {
        barrier = gameObject;
        torch = other.gameObject;
        if (torch.GetComponent<FireLightable>().flameObj.activeSelf == true)
        {
            Destroy(barrier);
        }
    }
}