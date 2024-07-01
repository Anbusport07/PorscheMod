using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CompanionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject companionGO;
    [SerializeField]
    private Transform fieldPos;
    [SerializeField]
    private Transform TargetPos;
    [SerializeField]
    private float offsetDistance;
    [SerializeField]
    [Range(10, 50)]
    private float heightPercentageValue;
    [SerializeField]
    private float companionReachTime;
    [SerializeField]
    private float lookRotationSpeed;
    [SerializeField]
    private Vector3 offsetPos;

    private NavMeshAgent companionAgent;

    [SerializeField]
    private Animator cAnimator;
    [SerializeField]
    private TextMeshProUGUI statusText;
    private bool currentStatus;

    private void Start()
    {
        //AppManager.Instance.OnFloorActive?.AddListener(Display);

        if(companionAgent == null)
            companionAgent = companionGO.GetComponent<NavMeshAgent>();

        currentStatus = false;
    }

    private void OnDisable()
    {
        //AppManager.Instance?.OnFloorActive?.RemoveListener(Display);
    }

    private void Update()
    {
        if (companionGO.activeInHierarchy == false)
            return;

        LookAt();

        if (CanMove(companionGO.transform.position, TargetPos.transform.position))
        {
            MovePos();
        }
    }

    private void Display(bool status)
    {
        companionGO.SetActive(status);
    }

    private void MovePos()
    {
        Vector3 newPos = new Vector3(fieldPos.position.x, fieldPos.position.y + offsetPos.y, fieldPos.position.z);

        companionAgent.SetDestination(newPos);
    }

    private bool CanMove(Vector3 currentPos, Vector3 targetPos)
    {
        return (Vector3.Distance(currentPos, targetPos) > offsetDistance);
    }

    private void LookAt()
    {
        var lookPos = TargetPos.position - companionGO.transform.position;
        var rotateTo = Mathf.Atan2(lookPos.x, lookPos.z) * Mathf.Rad2Deg;

        var rotation = Quaternion.Euler(0, rotateTo, 0);
        companionGO.transform.rotation = Quaternion.Slerp(companionGO.transform.rotation, rotation, Time.deltaTime * lookRotationSpeed);
    }

    #region Companion Operation
    public void DisplayMenu()
    {
        currentStatus = !currentStatus;

        if(currentStatus)
        {
            cAnimator.Play("colorpop");
            statusText.text = "Pick a Color";
        }
        else
        {
            cAnimator.Play("reset");
            statusText.text = "Poke Me";
        }
    }
    #endregion
}
