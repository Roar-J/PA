using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    MouseCursorSetting cursor { get => MouseCursorSetting.current; }
    GameSetting gameSetting;

    bool isHintScroll;

    void Start()
    {
        gameSetting = FindObjectOfType<GameSetting>();
    }

    void Update()
    {
        var currentSelectObj = GetObjectFromMouseRaycast();
        var currentCursor = cursor.click1;

        if (!currentSelectObj) // 等于 if (currentSelectObj == null)
        {
            currentCursor = isHintScroll ? cursor.scroll : cursor.click1;
        }
        else if (gameSetting.IsDragging())
        {
            currentCursor = !Input.GetMouseButton(0) ? cursor.drag1 : cursor.drag2;
        }
        else
        {
            currentCursor = !Input.GetMouseButton(0) ? cursor.click1 : cursor.click2;
        }
        Cursor.SetCursor(currentCursor, new Vector2(0.5f, 0.5f), CursorMode.Auto);
    }

    GameObject GetObjectFromMouseRaycast()
    {
        GameObject gmObj = null;
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        if (hit) gmObj = hitInfo.collider.gameObject;
        return gmObj;
    }

    public void SetScrollHint(bool o)
    {
        isHintScroll = o;
    }
}
