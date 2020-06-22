using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Draggable : MonoBehaviour
{
    public Action onMouseDown;
    public Action onMouseUp;

    float startDistance;

    Rigidbody rgbody {get => GetComponent<Rigidbody>(); }

    protected virtual void OnMouseDown()
    {
        var camera = Camera.main;
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        startDistance = Vector3.Distance(transform.position, ray.origin);
        if (rgbody) rgbody.isKinematic = true;
    }

    protected virtual void OnMouseDrag()
    {
        var camera = Camera.main;
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        
        transform.position = ray.GetPoint(startDistance);
    }

    protected virtual void OnMouseUp()
    {
        if (rgbody) rgbody.isKinematic = false;
    }

/*
    Vector3 GetDeltaPosFromMouse()
    {
        var camera = Camera.main;
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        var distance = Vector3.Distance(transform.position, camera.transform.position);
        ray.origin
    }*/
}
