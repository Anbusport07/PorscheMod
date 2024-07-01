using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRayInteractor : MonoBehaviour
{
    public LayerMask layer;
    public float distance = 10f;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, distance, layer))
        {

        }
    }

}
