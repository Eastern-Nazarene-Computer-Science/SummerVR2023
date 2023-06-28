using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBash : MonoBehaviour
{
    public GameObject Dwayne; // the bashing rock
    public GameObject skullToBash;  // bashable item
    public float primeBashingForce; // set to private after figuring this out

    private bool CheckVelocity()
    {
        float currentV = Dwayne.GetComponent<Rigidbody>().velocity.magnitude;
        Debug.Log("velocity checked: " + Dwayne.GetComponent<Rigidbody>().velocity.magnitude);
        if (currentV >= primeBashingForce)
            return true;
        else return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("rock collision");
        if (collision.gameObject == skullToBash && CheckVelocity() == true)
        {
            Debug.Log("commence the bashing");
            Rigidbody skullRB = skullToBash.GetComponent<Rigidbody>();
            skullRB.constraints = RigidbodyConstraints.None;
            skullRB.useGravity = true; // assuming this is what we want idk
            skullToBash.GetComponentInChildren<SphereCollider>().enabled = true;
        }
    }
}
