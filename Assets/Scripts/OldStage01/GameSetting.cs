using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : SingleTon<GameSetting>
{
    public int status;
    public float catchingDistance = 3f;
    bool isDragging = false;

    GameObject draggingObject;

    void Start()
    {
        status = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isDragging)
            {
                draggingObject = GetObjectFromMouseRaycast();
                if (draggingObject)
                {
                    //if (draggingObject.GetComponent<UnDragable>()) return;
                    draggingObject.GetComponent<Rigidbody>().isKinematic = true;
                    isDragging = true;
                }
            }
            else if (draggingObject != null)
            {
                draggingObject.GetComponent<Rigidbody>().MovePosition(CalculateMouse3DVector());
            }
        }
        else
        {
            if (draggingObject != null)
            {
                draggingObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            isDragging = false;
        }
    }
    private GameObject GetObjectFromMouseRaycast()
    {
        GameObject gmObj = null;
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            if (IsDraggable(hitInfo.collider.gameObject))
            {
                gmObj = hitInfo.collider.gameObject;
            }
        }
        return gmObj;
    }
    private Vector3 CalculateMouse3DVector()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = catchingDistance;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        return v3;
    }

    public bool IsDraggable(GameObject obj)
    {
        return obj.GetComponent<Draggable>()
         && Vector3.Distance(obj.transform.position,transform.position) <= catchingDistance;
    }

    public bool IsDragging()
    {
        return draggingObject != null;
    }
}
