using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperToSocket : MonoBehaviour
{
    public GameObject newspaper1, newspaper2, newspaper3;  // newpapers needed to fall before socket spawns
    public Rigidbody otherpaper1, otherpaper2, otherpaper3, otherpaper4, otherpaper5, otherpaper6; // other papers to fall off door when open
    private Rigidbody[] otherpapers;
    private Rigidbody news1RB, news2RB, news3RB;
    public GameObject keyholeObject; // object with socket in door

    private void Start()
    {
        news1RB = newspaper1.GetComponent<Rigidbody>();
        news2RB = newspaper2.GetComponent<Rigidbody>();
        news3RB = newspaper3.GetComponent<Rigidbody>();
        otherpapers = new Rigidbody[] { otherpaper1, otherpaper2, otherpaper3, otherpaper4, otherpaper5, otherpaper6 };
    }

    private void FixedUpdate()
    {
        if(news1RB.useGravity && news2RB.useGravity && news3RB.useGravity) // if all three have gravity activated
        {
            keyholeObject.SetActive(true);
            foreach (Rigidbody papier in otherpapers) // make other papers on door fall
            {
                papier.useGravity = true;
            }
        }
    }
}
