using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float minFov = 20f;
    public float maxFov = 70f;
    public float sensitivity = 20f;

    float originalFov;
    bool isScrollOpened;

    float currentFOV {get => Camera.main.fieldOfView; set => Camera.main.fieldOfView = value;}

    void Update()
    {
        if (!isScrollOpened) return;

        float fov = currentFOV;
        fov -= Input.mouseScrollDelta.y * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        currentFOV = fov;
    }

    public void OpenScroll(bool o)
    {
        isScrollOpened = o;
        if (isScrollOpened)
            originalFov = currentFOV;
    }

    public IEnumerator FOVBackToOriginRoutine()
    {
        while(Mathf.Abs(currentFOV - originalFov) > 0.02f)
        {
            float d = Mathf.Abs(currentFOV - originalFov);
            currentFOV = d > 1f ?
                Mathf.Lerp(currentFOV, originalFov, Time.deltaTime * 2f) : 
                Mathf.MoveTowards(currentFOV, originalFov, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }
    }

    public bool IsMin { get => Camera.main.fieldOfView <= minFov; }
}
