using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraMover))]
public class CameraMoverEditor : Editor
{
    (Vector3 t, Quaternion r) originalTR;

    public override void OnInspectorGUI()
    {
        CameraMover self = (CameraMover)target;
        var cam = Camera.main.transform;
        bool isMovingCamera = cam.parent == self.transform;
        string buttonText = isMovingCamera ? "Move Back" : "Move Camera";

        DrawDefaultInspector();
        if (GUILayout.Button(buttonText))
        {
            if (!isMovingCamera)
            {
                originalTR.t = cam.position;
                originalTR.r = cam.rotation;
                cam.SetParent(self.transform);
                cam.SetPositionAndRotation(self.transform.position, self.transform.rotation);
            }
            else
            {
                cam.SetPositionAndRotation(originalTR.t, originalTR.r);
                cam.SetParent(null);
            }
        }
    }
}
