using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    
    public GameObject normalButtons;
    public GameObject capsButtons;
    private bool caps;
    
    public GameObject Enterdis;
    
    public TMP_InputField username;
    
    public Collider Login;

   // public APILogin apiLogin;

    string filename = "";
    // Start is called before the first frame update
    void Start()
    {
        caps = false;
        //filename = Application.dataPath + "/Namedata.csv";
        
    }

    public void Insertchar(string c)
    {
        inputField.text += c;
        
    }

    public void Deletechar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
        
    }
    public void Insertspace()
    {
        inputField.text += " ";
        
    }
    public void CapsPressed()
    {
        if (!caps)
        {
            normalButtons.SetActive(false);
            capsButtons.SetActive(true);
            caps = true;
        }
        else
        {
            normalButtons.SetActive(true);
            capsButtons.SetActive(false);
            caps = false;
        }
    }

    
    //On release of enter button turn the welcome card on
    public void OnEnter()
    {
        if(inputField.text.Length > 0)
        {
            Enterdis.gameObject.SetActive(false);
            Login.enabled = true;


        }
        
        else
        {
            return;
        }
    }

    /*public void Create()
    {
        apiLogin.userIDNumber = "";

        apiLogin.userIDNumber = username.text;
        
    }*/
    public void usrdata()
    {
        username.text = PlayerPrefs.GetString("username");
        
    }
    
    //public void timerdata()
    //{
    //    PlayerPrefs.SetString("time", timer.GetParsedText());
    //    PlayerPrefs.Save();
    //}

    
}
