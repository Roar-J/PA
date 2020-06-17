using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    float x = 0,y=0,z=0,q=0;
    public float Distance = 0.2f;//开门需要移动鼠标的水平距离
    public Animator DoorMovement;
    public GameSetting Status;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseDown ()
    {
        x = Input.mousePosition.x;
        
    }
    // Update is called once per frame
    void OnMouseUp()
    {
        y = Input.mousePosition.x;
        z = x - y;
        q = y - x;
        if (z>=Distance && Status.status == 0)
        {
            DoorMovement.SetBool("MoveDoor", true);
            Status.status = 1;
        }
        if (q>= Distance && Status.status == 5)
        {
            DoorMovement.SetBool("MoveDoor", false);    
        }
        
    }
}
