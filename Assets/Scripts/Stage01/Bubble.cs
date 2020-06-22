using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float time = 8f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    
}
