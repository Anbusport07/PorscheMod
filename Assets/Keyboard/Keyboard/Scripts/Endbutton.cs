using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Endbutton : MonoBehaviour
{
    public GameObject discard;
    public UnityEvent write;
    public void OnTriggerEnter(Collider other)
    {
        discard.SetActive(false);
    }
}
