using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GButtonScript : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    public bool _isPressed;
    public Vector3 _startPos;
    public ConfigurableJoint _joint;
    public bool Patterns;
    public Animator GDoormoves1;
    public Animator GDoormoves2;
    public Animator GDoormoves3;


    public UnityEvent onPressed, onReleased;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    public float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
    
        if (value < deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }


    public void Pressed()
    {
       // _isPressed = true;
       //onPressed.Invoke();
       // Debug.Log("Pressed");
 
        if (Patterns == true)

        {
            Patterns = false;
            GDoormoves1.SetInteger("stateChange", 1);
            GDoormoves2.SetInteger("stateChange", 1);
            GDoormoves3.SetInteger("stateChange", 1);
            Debug.Log("Nice, now try the other one");
        }

        else if (Patterns == false)
        {
            Patterns = true;
            GDoormoves1.SetInteger("stateChange", 2);
            GDoormoves2.SetInteger("stateChange", 2);
            GDoormoves3.SetInteger("stateChange", 2);
            Debug.Log("You did it!");
        }
    }

    public void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
