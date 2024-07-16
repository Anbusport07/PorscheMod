using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncRotation : MonoBehaviour
{
    public GameObject uiCarGO;
    public GameObject carModelGO;
    [SerializeField]
    private Grabbable grabbable;

    void Start()
    {
        grabbable = GetComponent<Grabbable>();

       // grabbable.WhenPointerEventRaised += Grabbable_WhenPointerEventRaised;
    }

    /*private void Grabbable_WhenPointerEventRaised(PointerEvent obj)
    {
        if(obj.Type == PointerEventType.Move)
        {
            UpdateCarRotation();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (grabbable.SelectingPointsCount >= 1)
        {
            /*Quaternion childrod = childCube.transform.rotation;
            Quaternion targetrod = new Quaternion(0, parentCube.transform.rotation.y, 0, parentCube.transform.rotation.w);
            Quaternion newrod = Quaternion.Lerp(childrod, targetrod, Time.deltaTime * 1f);
            childCube.transform.rotation = newrod;*/

            UpdateCarRotation();
        }
    }

    public void UpdateCarRotation()
    {
        Quaternion childrod = carModelGO.transform.rotation;
        Quaternion targetrod = new Quaternion(0, uiCarGO.transform.rotation.y, 0, uiCarGO.transform.rotation.w);
        Quaternion newrod = Quaternion.Lerp(childrod, targetrod, Time.deltaTime * 1f);
        carModelGO.transform.rotation = newrod;
    }
}
