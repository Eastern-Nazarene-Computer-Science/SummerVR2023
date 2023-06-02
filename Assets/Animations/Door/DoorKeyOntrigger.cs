using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorKeyOntrigger : MonoBehaviour
{
    public Animator DoorAnimations;

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        Debug.Log("OnSelectEnter");
        Debug.Log(args.interactorObject.transform.gameObject.name);
        //if (args.interactorObject.transform.gameObject.name == "decimated_key2")
        {
            DoorAnimations.SetInteger("stateChange", 1);
            Debug.Log("stateChange 1");
        }
        //else
        //{
        //    DoorAnimations.SetInteger("stateChange", 0);
        //}
    }

    public void OnSelectExit()
    {
        //if (other.gameObject.name == "decimated_key2")
        //{
            DoorAnimations.SetInteger("stateChange", 1);
            Debug.Log("stateChange 1");
        //}
        //else
        //{
        //   DoorAnimations.SetInteger("stateChange", 2);
        //}
    }
}
