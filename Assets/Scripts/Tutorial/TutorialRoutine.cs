using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toturial
{
    public class TutorialRoutine : MonoBehaviour
    {
        public Transform cameraStartRoot;
        public Interactable toSwitchTrigger;
        public Transform cameraRootNextToSwitch;
        public GameObject roomLights;
        public GameObject stage01Routine;

        IEnumerator Start()
        {
            var playerCamera = FindObjectOfType<PlayerCamera>();
            var theSwitch = FindObjectOfType<Switch>();

            yield return playerCamera.LerpTo(cameraStartRoot, 2f);

            bool moving = false;
            toSwitchTrigger.gameObject.SetActive(true);
            toSwitchTrigger.onClickBegin = () => moving = true;
            yield return new WaitUntil ( () => moving);
            toSwitchTrigger.gameObject.SetActive(false);
            yield return playerCamera.LerpTo(cameraRootNextToSwitch, 2f);

            theSwitch.enabled = true;
            yield return new WaitUntil(() => theSwitch.isOpened);
            theSwitch.enabled = false;

            roomLights.SetActive(true);
            stage01Routine.SetActive(true);
        }
    }
}