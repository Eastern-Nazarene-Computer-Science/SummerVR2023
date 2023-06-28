using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    public Animator DoorAnimations;
    public void OpenWoodDoor()
    {
        DoorAnimations.SetInteger("stateChange", 3);
    }
}
