using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.SetActive(false);

    }
}
