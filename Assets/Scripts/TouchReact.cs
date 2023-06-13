using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchReact : MonoBehaviour
{
    public void TouchOpenCrate()
    {
        gameObject.GetComponent<Animator>().Play("OpenCrate");
    }
}
