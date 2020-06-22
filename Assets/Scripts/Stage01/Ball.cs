using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage01
{
    public class Ball : Interactable
    {
        public SoundFx ballJumpSound;
        public float jumpForce = 5f;
        public Vector3 rollSpeed;
        public Vector3 rollAngularSpeed;

        public bool isRolling;

        public void Jump()
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ballJumpSound.Play();
        }

        public void Roll()
        {
            GetComponent<Rigidbody>().velocity = rollSpeed;
            GetComponent<Rigidbody>().angularVelocity = rollAngularSpeed;
            isRolling = true;
        }
    }
}