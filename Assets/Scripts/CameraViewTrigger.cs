using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraViewTrigger : MonoBehaviour
{
    public bool autoClose = true;
    public bool autoToOrigin = true;
    public UnityEvent action;
    public UnityEvent actionEnd;

    IEnumerator Start()
    {
        PlayerCamera.current.OpenScroll(true);
        yield return new WaitUntil(()=>PlayerCamera.current.IsMin);
        if (action != null)
            action.Invoke();
        
        if (autoToOrigin)
        {
            yield return PlayerCamera.current.FOVBackToOriginRoutine();
            if (actionEnd != null)
                actionEnd.Invoke();
        }
        if (autoClose)
            gameObject.SetActive(false);
        PlayerCamera.current.OpenScroll(false);
    }
}
