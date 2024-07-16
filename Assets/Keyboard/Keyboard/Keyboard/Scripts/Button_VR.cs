/**************************************************
Copyright : Copyright (c) RealaryVR. All rights reserved.
Description: Script for VR Button functionality.
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HotColdWork
{
    public class Button_VR : MonoBehaviour
    {
        public string triggerName = "hand";
        public GameObject button;
        public UnityEvent onPress;
        public UnityEvent onRelease;
        GameObject presser;
        AudioSource sound;
        bool isPressed;

        //HC_StepManager stepManager;

        public bool dontInvokeStepEvent;
        void Start()
        {
            sound = GetComponent<AudioSource>();
            isPressed = false;
            /*if(HC_StepManager.instance != null)
                stepManager = HC_StepManager.instance;*/
        }

        private void OnTriggerEnter(Collider other)
        {
           if (other.gameObject.tag == triggerName)
            {
                if (!isPressed)
                {
                    button.transform.localPosition = new Vector3(0, 0.003f, 0);
                    presser = other.gameObject;
                    onPress.Invoke();
                    //sound.Play();
                    isPressed = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == presser)
            {
                button.transform.localPosition = new Vector3(0, 0.015f, 0);
                onRelease.Invoke();
                isPressed = false;
                /*if (stepManager != null)
                {
                    if (!dontInvokeStepEvent)
                        stepManager.steps[stepManager.stepCount].triggerEvent.Invoke();
                }*/
            }
        }
    }
}