using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPeeking : MonoBehaviour
{
    public GameObject camBlock;
    private float headRadius = 0.025f;
    private SphereCollider headColl;
    [SerializeField] private LayerMask collisionLayer;
    private void Start()
    {
        headColl = gameObject.GetComponent<SphereCollider>();
    }
    private void Update()
    {
        if(Physics.CheckSphere(gameObject.transform.position, headRadius, collisionLayer, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(camBlock.activeSelf);
        } else
        {
            if(camBlock.activeSelf == true)
            {
                camBlock.SetActive(false);
            }
        }
    }
}
