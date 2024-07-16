using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

        public List<GameObject> Enable = new List<GameObject>();
        public List<GameObject> Disable = new List<GameObject>();
        //public List<Collider> ColliderOn = new List<Collider>();
        //public List<Collider> ColliderOff = new List<Collider>();
        private void OnTriggerEnter(Collider other)
        {
            foreach (GameObject gameObject in Disable)
                Enableanddisable(gameObject, false);
            foreach (GameObject gameObject in Enable)
                Enableanddisable(gameObject, true);
            //foreach (Collider collider in ColliderOn)
            //    SetColliderEnabled(collider, true);
            //foreach (Collider collider in ColliderOff)
            //    SetColliderEnabled(collider, false);
        }
        public void Enableanddisable(GameObject gameObject, bool isEnable)
        {
            gameObject.SetActive(isEnable);
        }
        void SetColliderEnabled(Collider collider, bool isEnabled)
        {
            collider.enabled = isEnabled;
        }
        
    }

