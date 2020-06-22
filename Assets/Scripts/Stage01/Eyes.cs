using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage01
{
    public class Eyes : MonoBehaviour
    {
        public enum Animation {Sleepy, SlightlyOpened, Refreshed, Excited, Happy}

        [SerializeField] List<GameObject> eyePrefabs;

        GameObject currentEyes;
        Stack<(Animation anim, float time)> animStack = new Stack<(Animation, float)>();

        IEnumerator Start()
        {
            while(enabled)
            {
                if (animStack.Count > 0)
                {
                    var peek = animStack.Peek();
                    int n = (int)animStack.Peek().anim;
                    float time = animStack.Peek().time;
                    GameObject targetEyesPrefab = eyePrefabs[n];

                    if (currentEyes) DestroyImmediate(currentEyes);
                    currentEyes = Instantiate(targetEyesPrefab);

                    if (time > 0f)
                    {
                        yield return new WaitForSeconds(time);
                        animStack.Pop();
                    }
                    else
                        yield return new WaitUntil( () => peek != animStack.Peek());
                }
                else
                    yield return new WaitForEndOfFrame();
            }
        }
        
        public void PlayAnimation(Animation a, float time = -1f)
        {
            animStack.Push((a, time));
        }

        public void Pop()
        {
            animStack.Pop();
        }
    }

}