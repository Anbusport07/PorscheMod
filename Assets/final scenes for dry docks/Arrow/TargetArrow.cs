using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace Hazards
{
    public class TargetArrow : MonoBehaviour
    {
        private Camera CenterEyeAnchor;
        [HideInInspector]
        public GameObject arrow;

        private GameObject[] cameras;

        public GameObject uiCards;
        float angleBetween;

        public GameObject ovrPlayer;
        private void Start()
        {

            cameras = GameObject.FindGameObjectsWithTag("MainCamera");
            ovrPlayer = GameObject.FindGameObjectWithTag("Player");
            foreach (GameObject cam in cameras)
            {

                if (cam.name == "CenterEyeAnchor")
                {

                    CenterEyeAnchor = cam.GetComponent<Camera>();

                }

            }
            uiCards = GameObject.FindGameObjectWithTag("UICard");
        }
        private void Update()
        {
            /*RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform == target)
                {
                    arrow.SetActive(false);
                }
                else
                {
                    arrow.SetActive(true);
                }
            }*/


            if (CenterEyeAnchor != null)
            {
                Vector3 viewportPoint = CenterEyeAnchor.WorldToViewportPoint(transform.position);
                if ((viewportPoint.x >= 0.1 && viewportPoint.x <= 0.8 &&
                    viewportPoint.y >= 0.2 && viewportPoint.y <= 0.9 &&
                    viewportPoint.z > 0))
                {
                    arrow.SetActive(false);
                }
                else
                {
                    arrow.SetActive(true);
                }
            }
        }
    }
}
