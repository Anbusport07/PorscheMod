using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hazards
{
    public class H_Arrow_Manager : MonoBehaviour
    {
        private Transform CenterEyeAnchorTransform;
        private GameObject[] cameras;
        private GameObject centerEyeAnchor;
        private CameraState camStste;

        private void Awake()
        {

            gameObject.tag = "arrow";

        }


        private void Start()
        {

            cameras = GameObject.FindGameObjectsWithTag("MainCamera");




            foreach (GameObject cam in cameras)
            {

                if (cam.name == "CenterEyeAnchor")
                {

                    centerEyeAnchor = cam;
                    CenterEyeAnchorTransform = centerEyeAnchor.transform;
                    camStste = CameraState.Availble;

                }


            }
            if (centerEyeAnchor == null)
            {
                camStste = CameraState.notAvailble;
            }



        }

        void Update()
        {
            if (camStste == CameraState.Availble)
            {
                //transform.position = CenterEyeAnchorTransform.position;
                //transform.rotation = CenterEyeAnchorTransform.rotation;
            }

        }

        public enum CameraState
        {
            idle,
            Availble,
            notAvailble,
        }
    }
}
