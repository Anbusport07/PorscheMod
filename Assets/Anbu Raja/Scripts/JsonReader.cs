using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

using static JsonReader;

public class JsonReader : MonoBehaviour
{

    [SerializeField]
    private GameObject carModel;
    [SerializeField]
    private Texture[] carTextures;
    [SerializeField]
    private GameObject[] rims;

    public static JsonReader Instance;

    private float checkInterval = 5f;
 
    [SerializeField]
    private string URL = "";

    private string tempURL;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        } else
        {
            Instance = this;
        }
    }

    public CarList carListobj;

    [System.Serializable]
    public class Car
    {
        /*public string Brand;
        public string Modelname;
        public string FuelType;
        public string Colour;
        public string Type;*/
        public string ColorID;
        public string RimID;
    }

    [System.Serializable]
    public class CarList
    {
        public Car[] car;
    }

   

    private void Start()
    {
        tempURL = URL;
        StartCoroutine(checkperiodically());
        //carListobj = JsonUtility.FromJson<CarList>(textJson.text);
    }

    private IEnumerator checkperiodically()
    {
        while (true)
        {
            var id = new System.Random().Next(0, 10000000);
            URL = "";
            URL = tempURL + "?v=" + id;
            Debug.Log(URL);
            yield return new WaitForSeconds(checkInterval);

            yield return GetJsonData();
        }
    }


    private IEnumerator GetJsonData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            } else
            {
                Debug.Log("Successfully downloaded text");
                string jsonVal = request.downloadHandler.text;
                try
                {
                    carListobj = new CarList();
                    carListobj = JsonUtility.FromJson<CarList>(jsonVal);
                    if (carListobj == null || carListobj.car == null)
                    {
                        Debug.Log("Failed to load json");
                        
                    }
                    ChangesAffectedintheCar();

                } catch(Exception e)
                {
                    Debug.Log(e);
                }
            }
            request.Dispose();
        }

    }

    private void ChangesAffectedintheCar()
    {
        string colorID = "";
        string rimID = "";
        int castcolorID;
        int castrimID;
        foreach (Car car in carListobj.car)
        {
             colorID = car.ColorID;
             rimID = car.RimID;

        }

        int.TryParse(colorID, out castcolorID);
        int.TryParse(rimID, out castrimID);

        //Texture Update
        Material mat = carModel.GetComponent<Renderer>().materials[14];
        mat.SetTexture("_BaseMap", carTextures[castcolorID]);

        //Rim Update
        if(castrimID != -1)
        {
            foreach(GameObject rim in rims)
            {
                rim.SetActive(false);
            }
            rims[castrimID].SetActive(true);
        }




        //Reset Values
         colorID = "";
         rimID = "";
         castcolorID = -1;
         castrimID = -1;
    }
}
