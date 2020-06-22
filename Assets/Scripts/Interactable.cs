using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public enum Type { Drag, Click, None }

    public Type type;
    public bool isClicked;
    public Action onDragBegin = () => {};
    public Action onDragEnd = () => {};
    public Action onMouseEnter = () => { };
    public Action onMouseExit = () => { };
    public Action onClickBegin = () => { };
    public Action onClickEnd = () => { };

    float startDistance;

    public Rigidbody rgbody { get => GetComponent<Rigidbody>(); }
    public new Collider collider { get => GetComponent<Collider>(); }

    protected virtual void OnMouseDown()
    {
        if (type == Type.Drag)
        {
            var camera = Camera.main;
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            startDistance = Vector3.Distance(transform.position, ray.origin);
            if (rgbody) rgbody.isKinematic = true;

            onDragBegin.Invoke();
        }
        else if (type == Type.Click)
        {
            onClickBegin.Invoke();
            isClicked = true;
        }
    }

    protected virtual void OnMouseDrag()
    {
        if (type == Type.Drag)
        {
            var camera = Camera.main;
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(startDistance);
        }
    }

    protected virtual void OnMouseUp()
    {

        if (type == Type.Drag)
        {
            if (rgbody) rgbody.isKinematic = false;

            onDragEnd.Invoke();
        }
        else if (type == Type.Click)
        {
            onClickEnd.Invoke();
        }
    }

    void OnMouseEnter()
    {
        onMouseEnter.Invoke();
    }
    
    void OnMouseExit()
    {
        onMouseExit.Invoke();
    }
}
