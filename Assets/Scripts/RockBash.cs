using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBash : MonoBehaviour
{
    public GameObject Dwayne; // the bashing rock
    public GameObject skullToBash;  // bashable item
    public Vector3 primeBashingForce; // set to private after figuring this out

    private bool CheckVelocity()
    {
        Debug.Log("velocity checked");
        Vector3 currentV = Dwayne.GetComponent<Rigidbody>().velocity;
        if (currentV.x >= primeBashingForce.x && currentV.y >= primeBashingForce.y && currentV.z >= primeBashingForce.z)
            return true;
        else return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject == Dwayne && CheckVelocity() == true)
        {
            Debug.Log("commence the bashing");
            Rigidbody skullRB = skullToBash.GetComponent<Rigidbody>();
            skullRB.constraints = RigidbodyConstraints.None;
            skullRB.useGravity = true; // assuming this is what we want idk

        }
    }
}
