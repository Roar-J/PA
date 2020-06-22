using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Toturial
{
    public class Switch : Interactable
    {
        public bool isOpened;

        void Start()
        {
            type = Interactable.Type.Click;
            onClickBegin = Open;
        }

        public void Open()
        {
            isOpened = true;
            GetComponentInChildren<PlayableDirector>().Play();
        }

    }
}