using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage01
{
    public class Clothes : Interactable
    {
        public Vector3 startPosition;
        public Vector3 throwOutPosition = new Vector3(0,1,-1);
        public Vector3 throwOutVelocity = new Vector3(0,0,-5f);
        public Vector3 throwInPosition = new Vector3(0,0.8f,-0.7f);
        public SoundFx throwOutSound;
        public SoundFx throwInSound;
        public bool isInWashingMachine;

        public void ThrowToWashingMachine()
        {
            isInWashingMachine = true;
            transform.position = throwInPosition;
            throwInSound.Play();
        }

        public void ThrowOutOfWashingMachine()
        {
            transform.position = throwOutPosition;
            GetComponent<Rigidbody>().velocity = throwOutVelocity;
            throwOutSound.Play();
        }
    }
}