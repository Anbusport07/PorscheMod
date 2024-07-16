using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{

   public void Select()
    {
        Debug.Log("Hand Shape is correct");
    }

    public void unSelect()
    {
        Debug.Log("Hand is not in that pose");
    }
}
