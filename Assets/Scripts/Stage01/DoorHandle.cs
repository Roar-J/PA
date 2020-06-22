using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage01
{
    public class DoorHandle : Interactable
    {
        public float distanceForOpen = 0.2f;
        public Vector2 startMousePos;
        public bool isOpened;
        public Animator DoorMovement;
        public SoundFx doorOpenSound;
        public SoundFx doorCloseSound;

        void Start()
        {
            var doorHandle = this;
            doorHandle.onClickBegin = () => doorHandle.startMousePos = Input.mousePosition;
            doorHandle.onClickEnd = () => 
            {
                float distance = doorHandle.startMousePos.x - Input.mousePosition.x;
                if (distance >= doorHandle.distanceForOpen)
                    Open();
                else if (distance <= distanceForOpen)
                    Close();
            };
        }

        public void Open()
        {
            if(!enabled) return;
            isOpened = true;
            DoorMovement.SetBool("MoveDoor", true);
            doorOpenSound.Play();
        }

        public void Close()
        {
            if(!enabled) return;
            isOpened = false;
            DoorMovement.SetBool("MoveDoor", false);   
            doorCloseSound.Play(); 
        }
    }
}