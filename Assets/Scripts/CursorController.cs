using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : SingleTon<CursorController>
{
    MouseCursorSetting cursorData { get => MouseCursorSetting.current; }

    public void SetCursor(CursorType t)
    {
        int n = (int)t;
        var targetCursor = t == CursorType.None ? null : cursorData.cursors[n];
        Cursor.SetCursor(targetCursor, cursorData.offset, CursorMode.Auto);
    }
}

public enum CursorType
{
    Click1, Click2, Drag1, Drag2, Scroll, None
}