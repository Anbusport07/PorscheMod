using Meta.XR.Locomotion.Teleporter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskFocusHandler : MonoBehaviour
{
    [SerializeField]
    private Transform currentTarget;
    [SerializeField]
    private Image arrowImage;

    private void Update()
    {
        if (currentTarget == null)
            return;

        Vector3 target = transform.InverseTransformPoint(currentTarget.position);

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        transform.Rotate(0,0, angle);

        var distance = Vector3.Distance(this.transform.position, currentTarget.position);

        if(distance < 1.2f || distance > 1.6f)
        {
            arrowImage.enabled = false;
        }
        else
        {
            arrowImage.enabled = true;
        }

        //Debug.Log($"Distance {distance}");
    }

    public void UpdateTargetTransform(Transform uTarget)
    {
        currentTarget = uTarget;
    }
}
