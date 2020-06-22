using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage01
{
    public class Routine : MonoBehaviour
    {
        public GameObject washingMachineBubble;
        public InteractableTrigger clothesToWashingMachineTrigger;
        public Interactable doorScrollHintTrigger;
        public SoundFx findCatSound;
        public GameObject findCatBubble;
        public InteractableTrigger catSeeBallTrigger;
        public GameObject whatDoesCatLikeBubble;

        IEnumerator Start()
        {
            var eyes = FindObjectOfType<Eyes>();
            var ball = FindObjectOfType<Ball>();
            var clothes = FindObjectOfType<Clothes>();
            var doorHandle = FindObjectOfType<DoorHandle>();
            var playerCamera = FindObjectOfType<PlayerCamera>();
            var cat = FindObjectOfType<Cat>();
            var washingMachine = FindObjectOfType<WashingMachine>(); 

            clothesToWashingMachineTrigger.gameObject.SetActive(false);
            doorScrollHintTrigger.gameObject.SetActive(false);
            playerCamera.OpenScroll(false);

            //state 1
            eyes.PlayAnimation(Eyes.Animation.Sleepy);
            washingMachineBubble.SetActive(true);
            ball.onClickBegin = () => 
            {
                ball.Jump();
                CursorController.current.SetCursor(CursorType.None);
            };
            ball.onMouseEnter = () => CursorController.current.SetCursor(CursorType.Click1);
            ball.onMouseExit = () => CursorController.current.SetCursor(CursorType.None);
            clothes.startPosition = clothes.transform.position;
            clothes.onMouseEnter = () => CursorController.current.SetCursor(CursorType.Click1);
            clothes.onMouseExit = () => {
                CursorController.current.SetCursor(CursorType.None);
            };
            clothes.onDragEnd = () => clothes.transform.position = clothes.startPosition;
            doorHandle.enabled = true;

            //Open the Door
            yield return new WaitUntil( () => doorHandle.isOpened );
            doorHandle.enabled = false;
            washingMachineBubble.SetActive(false);

            //state 2
            eyes.PlayAnimation(Eyes.Animation.SlightlyOpened);
            ball.onClickBegin += () => eyes.PlayAnimation(Eyes.Animation.Refreshed, 1f);
            clothes.onDragBegin += () => clothesToWashingMachineTrigger.gameObject.SetActive(true);
            clothes.onDragEnd = () =>
            {
                if (clothesToWashingMachineTrigger.touchingObject == clothes)
                {
                    clothes.ThrowOutOfWashingMachine();
                    eyes.PlayAnimation(Eyes.Animation.Refreshed, 1f);
                }
                else
                {
                    clothes.transform.position = clothes.startPosition;
                }
                clothesToWashingMachineTrigger.gameObject.SetActive(false);
            };
            doorScrollHintTrigger.gameObject.SetActive(true);
            doorScrollHintTrigger.onMouseEnter = () => CursorController.current.SetCursor(CursorType.Scroll);
            doorScrollHintTrigger.onMouseExit = () => CursorController.current.SetCursor(CursorType.None);
            playerCamera.OpenScroll(true);

            //Spot the Cat
            yield return new WaitUntil( () => playerCamera.IsMin);
            CursorController.current.SetCursor(CursorType.None);
            findCatBubble.SetActive(true);
            findCatSound.Play();
            doorScrollHintTrigger.gameObject.SetActive(false);
            yield return new WaitForSeconds(findCatSound.clip.length + 1f);
            playerCamera.OpenScroll(false);
            yield return playerCamera.FOVBackToOriginRoutine();

            //state 3
            ball.onClickBegin = ball.Roll;
            whatDoesCatLikeBubble.SetActive(true);

            //Click the ball
            yield return new WaitUntil( () => ball.isRolling );

            //state 4
            catSeeBallTrigger.gameObject.SetActive(true);
            yield return new WaitUntil( () => catSeeBallTrigger.touchingObject == ball);
            catSeeBallTrigger.gameObject.SetActive(false);
            cat.JumpOut();
            clothesToWashingMachineTrigger.gameObject.SetActive(true);
            clothes.onDragEnd = () => 
            {
                if (clothesToWashingMachineTrigger.touchingObject == clothes)
                {
                    clothes.ThrowToWashingMachine();
                }
                else
                {
                    clothes.transform.position = clothes.startPosition;
                }
                clothesToWashingMachineTrigger.gameObject.SetActive(false);
            };
            
            //Put in the clothes
            yield return new WaitUntil ( () => clothes.isInWashingMachine );
            yield return new WaitForSeconds(1f);

            //state 5
            doorHandle.enabled = true;
            yield return new WaitUntil( () => !doorHandle.isOpened );
            doorHandle.enabled = false;
            yield return new WaitForSeconds(1f);
            washingMachine.Work();
            eyes.PlayAnimation(Eyes.Animation.Happy);

            yield break;
        }
    }
}