using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerVelocity : MonoBehaviour
{
    public InputActionProperty deviceVelocityProperty;

    public Vector3 Velocity { get; private set; } = Vector3.zero;

    private void Update()
    {
        Velocity = deviceVelocityProperty.action.ReadValue<Vector3>();
    }
}
