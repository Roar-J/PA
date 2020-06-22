using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : MonoBehaviour
{
    public SoundFx workSound;

    public void Work()
    {
        workSound.Play();
    }
}
