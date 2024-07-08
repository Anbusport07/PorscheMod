using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncRotation : MonoBehaviour
{
    public GameObject parentCube;
    public GameObject childCube;
    [SerializeField]
    private Grabbable grabbable;

    void Start()
    {
        grabbable = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.enabled)
        {
            Quaternion childrod = childCube.transform.rotation;
            Quaternion targetrod = parentCube.transform.rotation;
            Quaternion newrod = Quaternion.Lerp(childrod, targetrod, Time.deltaTime * 1f);
            childCube.transform.rotation = newrod;
        }
    }
}
