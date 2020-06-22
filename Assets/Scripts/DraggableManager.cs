using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableManager : SingleTon<DraggableManager>
{

    public float catchingDistance = 3f;
    bool isDragging = false;

    public Draggable draggingObject;

    void Start()
    {
        draggingObject = null;
    }

    void Update()
    {
        if (draggingObject != null)
        {
            if (!isDragging)
            {
                GameObject gmObj = null;
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    if (IsDraggable(hitInfo.collider.gameObject))
                        gmObj = hitInfo.collider.gameObject;
                }
                draggingObject = gmObj.GetComponent<Draggable>();
                if (draggingObject)
                {
                    draggingObject.GetComponent<Rigidbody>().isKinematic = true;
                    isDragging = true;
                }
            }
            else if (draggingObject != null)
            {
                Vector3 v3 = Input.mousePosition;
                v3.z = catchingDistance;
                v3 = Camera.main.ScreenToWorldPoint(v3);
                draggingObject.GetComponent<Rigidbody>().MovePosition(v3);
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
