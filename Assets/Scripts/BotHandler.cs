using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class BotHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnTapMe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Palm"))
        {
            OnTapMe?.Invoke();
        }
    }
}
