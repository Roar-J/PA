﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickTrigger : MonoBehaviour
{
    public bool autoClose = true;
    public bool changeCursor = true;
    public UnityEvent action;

    void OnMouseDown()
    {
        if (!enabled) return;
        if (action != null) action.Invoke();
        if (autoClose) gameObject.SetActive(true);
    }

    void OnMouseEnter()
    {
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.Click1);
    }

    void OnMouseExit()
    {
        if (changeCursor)
            CursorController.current.SetCursor(CursorType.None);
    }
}