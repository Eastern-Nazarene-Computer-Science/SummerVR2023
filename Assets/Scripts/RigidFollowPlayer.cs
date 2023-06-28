using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RigidFollowPlayer : MonoBehaviour
{
    CapsuleCollider capsule;
    Rigidbody playerRB;
    float playerHeight;
    public GameObject mainCamera;
    public XROrigin xrbruh;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        capsule = gameObject.GetComponent<CapsuleCollider>();
        playerHeight = mainCamera.transform.position.y;
        capsule.height = playerHeight;
        capsule.center = new Vector3(mainCamera.transform.localPosition.x, -playerHeight + 0.5f, mainCamera.transform.localPosition.z);
    }

}
