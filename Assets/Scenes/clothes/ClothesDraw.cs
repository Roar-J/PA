using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesDraw : MonoBehaviour
{
    public float F;
    public Trigger trigger;
    public GameSetting Status;
    public Collider bill;
    void OnMouseDown()
    {
        bill.gameObject.SetActive(true);
    }
    void OnMouseUp()
    {
        if (trigger.Bill == this.GetComponent<BoxCollider>() && (Status.status == 1||Status.status == 3))
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = new Vector3(0,1,-1);
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,-1) * F;
        }
        else if(trigger.Bill == this.GetComponent<BoxCollider>() && (Status.status == 4))
        {
            transform.position = new Vector3(0,0.8f,-0.7f);
            Status.status = 5;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = new Vector3(0,0,-3);
        }
    bill.gameObject.SetActive(false);
    trigger.Bill = null;
    }
}
