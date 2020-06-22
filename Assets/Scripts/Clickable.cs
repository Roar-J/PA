using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clickable : MonoBehaviour
{
    public Action onClick = () => {};
    
    void OnMouseDown()
    {
        onClick.Invoke();
    }
}
