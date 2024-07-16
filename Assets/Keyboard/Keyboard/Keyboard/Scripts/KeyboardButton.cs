using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HotColdWork;
public class KeyboardButton : MonoBehaviour
{
    Keyboard keyboard;
    TextMeshProUGUI buttonText;

    private void Start()
    {
        keyboard = GetComponentInParent<Keyboard>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (buttonText.text.Length == 1)
        {
            NameToButtonText();
            GetComponentInChildren<Button_VR>().onRelease.AddListener(delegate { keyboard.Insertchar(buttonText.text); });
            Debug.Log("Clicked");
        }
    }

    public void NameToButtonText()
    {
        buttonText.text = gameObject.name;
    }
}
    
