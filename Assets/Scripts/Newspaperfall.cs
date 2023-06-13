using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaperfall : MonoBehaviour
{
    public void NewspaperFallFunction()
    {
        Debug.Log("words");
        Rigidbody thisRB = gameObject.GetComponent<Rigidbody>();
        Debug.Log(thisRB.constraints);
        thisRB.constraints = RigidbodyConstraints.None;
        thisRB.useGravity = true;
    
    }
}
