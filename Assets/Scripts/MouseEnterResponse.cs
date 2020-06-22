using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseEnterResponse : MonoBehaviour
{
    public Action onMouseEnter = () => {};
    public Action onMouseExit = () => {};

    void OnMouseEnter()
    {
        onMouseEnter.Invoke();
    }
    void OnMouseExit()
    {
        onMouseExit.Invoke();
    }
}
