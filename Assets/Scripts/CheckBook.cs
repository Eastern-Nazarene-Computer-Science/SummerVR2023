using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckBook : MonoBehaviour
{
    public GameObject book, light;
    private XRSocketInteractor socket;
    public void vCheckProperBook()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
        if (socket.GetOldestInteractableSelected() == book.GetComponent<IXRSelectInteractable>())
        {
            light.GetComponentInChildren<FireLightable>().LightFire();
        }
    }

    public void vProperBookExit()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
        if (socket.GetOldestInteractableSelected() != book.GetComponent<IXRSelectInteractable>())
        {
            light.GetComponentInChildren<FireLightable>().ExtFire();
        }
    }

    public bool CheckProperBook()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
        if (socket.GetOldestInteractableSelected() == book.GetComponent<IXRSelectInteractable>())
        {
            return true;
        }
        return false;
    }
}
