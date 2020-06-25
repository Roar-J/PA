using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Interactable : MonoBehaviour
{
    public enum Type { Drag, Click, None }

    public Type type;
    public bool isClicked;
    public UnityEvent onDragBegin;
    public UnityEvent onDragEnd;
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;
    public UnityEvent onClickBegin;
    public UnityEvent onClickEnd;

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

public static class InteractableExtension
{
    public static void SetListener(this UnityEvent e , UnityAction a)
    {
        e.RemoveAllListeners();
        e.AddListener(a);
    }
}