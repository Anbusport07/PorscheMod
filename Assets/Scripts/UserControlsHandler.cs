using TMPro;
using UnityEngine;

public class UserControlsHandler : MonoBehaviour
{
    public TMP_Text debugText;

    private void OnTriggerEnter(Collider other)
    {
        AppManager.Instance.OnFloorActive?.Invoke(true);
    }

    public void OnTriggerExit(Collider other)
    {
        AppManager.Instance.OnFloorActive?.Invoke(false);
    }
}