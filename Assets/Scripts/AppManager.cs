using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AppManager : MonoBehaviourSingleton<AppManager>
{
    public UnityEvent<int> OnChangeColor;

    public UnityEvent<bool> OnFloorActive;

    public Animator carAnimator;

    public void ShowDoorAnimation()
    {
        carAnimator.Play("door");

        Invoke(nameof(ShowCloseDoorAnimation), 3);
    }

    private void ShowCloseDoorAnimation()
    {
        carAnimator.Play("close");
    }
}
