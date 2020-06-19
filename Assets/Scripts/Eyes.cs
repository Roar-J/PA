using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public List<GameObject> eyePrefabs;

    GameObject currentEyes;
    int state = -1;

    GameSetting game {get => GameSetting.current;}
    

    void Update()
    {
        int realState = Mathf.Clamp(game.status, 0, eyePrefabs.Count - 1);
        if (state != realState)
        {
            state = realState;
            if (currentEyes) Destroy(currentEyes);
            currentEyes = Instantiate(eyePrefabs[state]);
        }

    }
}
