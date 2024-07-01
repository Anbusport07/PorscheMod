using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DryDocks.Utils
{
    public class WaitAndRun : MonoBehaviour
    {
        public bool runInStart;
        [Range(0f, 10f)]
        public float waitTime = 10f;
        public UnityEvent events;
        private void Start()
        {
            if (runInStart)
                Run();
        }
        public void Run()
        {
            StartCoroutine(WaitAndExecute());
        }
        IEnumerator WaitAndExecute()
        {
            yield return new WaitForSeconds(waitTime);
            events.Invoke();
        }
    }
}
