using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class RigidFollowPlayer : MonoBehaviour
{
    CapsuleCollider capsule;
    Rigidbody playerRB;
    float playerHeight;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        capsule = gameObject.GetComponent<CapsuleCollider>();
        playerHeight = gameObject.GetComponent<XROrigin>().CameraYOffset;
        capsule.height = playerHeight;
        capsule.center = new Vector3(0, playerHeight / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        capsule.center = new Vector3(mainCamera.transform.localPosition.x, playerHeight / 2, mainCamera.transform.localPosition.z);
    }
}
