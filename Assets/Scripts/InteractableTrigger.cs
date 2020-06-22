using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    public Interactable touchingObject;

    void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<Interactable>();
        if (obj)
            touchingObject = obj;

    }

    void OnTriggerExit(Collider other)
    {
        var obj = other.GetComponent<Interactable>();
        if (obj == touchingObject)
            touchingObject = null;
    }
}
