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
            //Destroy(barrier);
            Vector3 translation = new Vector3(2f, 0f, 0f) * Time.deltaTime;
            transform.Translate(translation);
        }
    }
}