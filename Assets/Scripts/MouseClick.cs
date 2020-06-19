using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Playables;

public class MouseClick : MonoBehaviour
{
    public float F = 5f;
    public PlayableDirector Cat;
    public float catRunOutDelay = 1f;
    public Vector3 Roll;
    public Vector3 Angular;
    public Vector3 speed;
    public SoundFx ballJumpSound;
    
    GameSetting Sta;

    void Start()
    {
        Sta = FindObjectOfType<GameSetting>();
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
            Invoke("CatRunOutOfWashingMachine", catRunOutDelay);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * F, ForceMode.Impulse);
            ballJumpSound.Play();
        }
    }

    void CatRunOutOfWashingMachine()
    {
        /*Previous code
        Cat.transform.position = (new Vector3(-3, 0.2f, -2));
        Quaternion q = gameObject.transform.rotation;
        Vector3 vr = q.eulerAngles;
        Cat.transform.eulerAngles = (new Vector3(0, -90, 0));
        Cat.GetComponent<Rigidbody>().velocity = speed;
        */
        Cat.enabled = true;
    }
}
