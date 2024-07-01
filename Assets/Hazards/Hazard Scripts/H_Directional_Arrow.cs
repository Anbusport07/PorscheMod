using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
namespace Hazards
{
    public class H_Directional_Arrow : MonoBehaviour
    {
        [SerializeField]
        public Transform target;

        public TargetArrow targetArrow;

        private GameObject arrow;


        private float customX = 1.211312f;
        private Transform[] chilArrow;
        public Transform childArrow1;
        private ArrowStatus arrowStatus;

        //------------------------------
        private float rotationSpeed = 10f;
        private float targetRotation = 90f;
        private float currentRotation = 0f;
        private float currentRotationdown = 0.1f;

        public void Start()
        {
            StartCoroutine(Init());
        }
        public void SetTargetLookAt(Transform lookAt)
        {
            ClearTarget();
            target = lookAt;
            StartCoroutine(Init());
        }
        public void ClearTarget()
        {
            target = null;
        }
        public IEnumerator Init()
        {

            //  arrowManager = GameObject.FindGameObjectWithTag("arrow");
            arrow = childArrow1.gameObject;
            if (target != null)
            {
                yield return new WaitUntil(() => target.gameObject.activeInHierarchy);

                if (target.GetComponent<TargetArrow>() == null)
                    target.AddComponent<TargetArrow>();

                targetArrow = target.GetComponent<TargetArrow>();
                targetArrow.arrow = arrow;
                arrowStatus = ArrowStatus.WeHaveArrow;
            }
            else
            {
                arrowStatus = ArrowStatus.weDontHaveArrow;
            }

            // childObjects[i] = childTransforms[i].gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (arrowStatus == ArrowStatus.WeHaveArrow)
            {
                Vector3 targetPosition = target.transform.position;
                transform.LookAt(targetPosition);

            }

            //if (transform.localRotation.y < 140)
            //{
            //    GetComponentInChildren<SpriteRenderer>().enabled = false;
            //}
            //else
            //{
            //    GetComponentInChildren<SpriteRenderer>().enabled = false;
            //}

        }

        public enum ArrowStatus
        {
            None,
            WeHaveArrow,
            weDontHaveArrow
        }
    }
}
