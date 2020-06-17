using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Collider Bill;
    void OnTriggerEnter (Collider other)
    {
        Bill = other;
    }
    void OnTriggerExit(Collider other)
    {
        Bill = null;
    }
}
