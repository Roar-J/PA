using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameSetting Sta;
    public float F = 5f;
    public GameObject Cat;
    public Vector3 Roll;
    public Vector3 Angular;
    public Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (Sta.status == 3)
        {
            GetComponent<Rigidbody>().velocity = Roll;
            GetComponent<Rigidbody>().angularVelocity = Angular;
            Sta.status = 4;
            Cat.transform.position = (new Vector3(-3,0.2f,-2));
            Quaternion q = gameObject.transform.rotation;
            Vector3 vr = q.eulerAngles;
            Cat.transform.eulerAngles = (new Vector3(0,-90,0));
            Cat.GetComponent<Rigidbody>().velocity = speed;
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * F, ForceMode.Impulse);
        }
    }
}
