using UnityEngine;

namespace XRLabs.DryDocks.Utils
{
    public class ResetBackToPoint : MonoBehaviour
    {

        [SerializeField] private Transform resetPosition;

        public void ResetPosition()
        {
            transform.position = resetPosition.position;
            transform.rotation = resetPosition.rotation;
        }
    }
}

