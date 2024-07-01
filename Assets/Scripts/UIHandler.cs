using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Animator floorAnim;

    public void DisplayUserInteraction(bool status)
    {
        Debug.Log($"Herere {status}");
        //Floor Animation
        //floorAnim.speed = (status ? 0f : 1f);

        //Display Gaurdian UI
    }

    public void ShowDoorAnimation()
    {
        //floorAnim.speed = 1;
        floorAnim.Play("open");

        Invoke(nameof(ShowCloseDoorAnimation), 5);
    }

    private void ShowCloseDoorAnimation()
    {
        floorAnim.Play("close");
    }
}
