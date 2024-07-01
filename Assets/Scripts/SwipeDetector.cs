using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class SwipeDetector : MonoBehaviour
{
    public TMP_Text debugText;
    public GameObject bonnet;
    public Animator charger;
    public string chargerAnim;
    public string chargerAnim_reset;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Palm"))
        {
            debugText.text = "Swiped"!;

            if (bonnet != null)
                LeanTween.rotateX(bonnet, -35f, 1f).setEase(LeanTweenType.linear);
            else
                //charger.Play(chargerAnim);
                charger.CrossFade("chargerAnim", 0, 0);

            Invoke("ResetDebugText", 5f);
        }
    }

    private void ResetDebugText()
    {
        if (bonnet != null)
            LeanTween.rotateX(bonnet, 0f, 1f).setEase(LeanTweenType.linear);
        else
        {
            //charger.Play(chargerAnim_reset);
            charger.CrossFade("chargerAnim_reset", 0, 0);
        }

        debugText.text = "Swipe here";
    }
}
