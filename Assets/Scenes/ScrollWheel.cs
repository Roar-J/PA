using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheel : MonoBehaviour
{
    public float minFov = 25f;
    public float maxFov = 30f;
    public float sensitivity = 20f;
    public GameSetting status;
    public float Jay;
    public Animator Cat;
    // Update is called once per frame
    void Start()
    {
        Jay = Camera.main.fieldOfView;
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
                Cat.SetFloat("Action", 1);
                status.status = 2;
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
