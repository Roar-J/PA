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
        public GameObject eyeBeforeSwitchOn;
        public GameObject roomLights;
        public Transform cameraRootAfterSwitchOn;
        public GameObject eyeAfterSwitchOn;
        public GameObject stage01Routine;

        IEnumerator Start()
        {
            var playerCamera = FindObjectOfType<PlayerCamera>();
            var theSwitch = FindObjectOfType<Switch>();

            yield return playerCamera.LerpTo(cameraStartRoot, 2f);

            bool moving = false;
            toSwitchTrigger.gameObject.SetActive(true);
            toSwitchTrigger.onClickBegin.SetListener(() => moving = true);
            yield return new WaitUntil ( () => moving);
            toSwitchTrigger.gameObject.SetActive(false);
            yield return playerCamera.LerpTo(cameraRootNextToSwitch, 2f);

            theSwitch.enabled = true;
            yield return new WaitUntil(() => theSwitch.isOpened);
            theSwitch.enabled = false;
            eyeAfterSwitchOn.SetActive(true);
            roomLights.SetActive(true);
            yield return playerCamera.LerpTo(cameraRootAfterSwitchOn, 2f);

            stage01Routine.SetActive(true);
        }
    }
}