using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    public GameObject BAT;
    private void OnTriggerEnter(Collider other)
    {
        BAT.GetComponent<BatAttackHandler>().BatTriggerEnter(other);
        Debug.Log("attack trigger");
        Destroy(gameObject);
    }
}
