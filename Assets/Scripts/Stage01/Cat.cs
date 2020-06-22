using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Stage01
{
    public class Cat : MonoBehaviour
    {
        public void JumpOut()
        {
            GetComponent<PlayableDirector>().enabled = true;
        }
    }
}