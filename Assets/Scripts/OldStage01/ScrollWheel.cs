using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheel : MonoBehaviour
{
    public float minFov = 25f;
    public float maxFov = 30f;
    public float sensitivity = 20f;
    public float Jay;
    public SoundFx findSomethingSound;
    
    GameSetting status;
    MouseCursorController cursorController;

    void Start()
    {
        Jay = Camera.main.fieldOfView;
        status = FindObjectOfType<GameSetting>();
        cursorController = FindObjectOfType<MouseCursorController>();
    }
    void Update()
    {
        if (status.status == 1)
        {
            float fov = Camera.main.fieldOfView;
            fov -= Input.mouseScrollDelta.y * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
            if (fov == minFov)
            {
                //Cat.SetFloat("Action", 1);
                status.status = 2;
                cursorController.SetScrollHint(false);
                findSomethingSound.Play();
            }
        }
        if (status.status == 2)
        {
            float fov = Camera.main.fieldOfView;
            fov -= Input.mouseScrollDelta.y * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
            if (fov >= Jay)
            {
                Camera.main.fieldOfView = Jay;
                status.status = 3;
            }
        }
    }
}
