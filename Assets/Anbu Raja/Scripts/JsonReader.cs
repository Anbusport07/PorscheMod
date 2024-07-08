using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

using static JsonReader;
using System.Linq;

public class JsonReader : MonoBehaviour
{
    [Tooltip("Json Data File Link")]
    [SerializeField]
    private string URL = "";

    [Tooltip("Car Gameobject Parts For Apply Texure at Run Time")]
    [SerializeField]
    private List<GameObject> carParts;

    [Tooltip("Pre Defined Textures")]
    [SerializeField]
    private Texture[] carTextures;

    [Tooltip("Collection of Wheel Cap")]
    [SerializeField]
    private GameObject[] rims;


    public static JsonReader Instance;

    private static float checkInterval = 5f;
    private string tempURL;
    private string timeStamp_temp;
    private string checkTimestamp;
    private bool isoneTime = false;



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
        public string ColorID;
        public string RimID;
        public string TextureID;
        public string url;
        public string Timestamp;
    }

    [System.Serializable]
    public class CarList
    {
        public Car[] car;
    }

    private WaitForSeconds intervel = new WaitForSeconds(checkInterval);

    private void Start()
    {
        tempURL = URL;
        StartCoroutine(checkperiodically());
    }

    private IEnumerator checkperiodically()
    {
        while (true)
        {
            var id = new System.Random().Next(0, 10000000);
            URL = "";
            URL = tempURL + "?v=" + id;
            yield return intervel;

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
       // string colorID = "";
        string rimID = "";
        string baseCode = "";
        //int castcolorID;
        int castrimID;

        foreach (Car car in carListobj.car)
        {
            // colorID = car.ColorID;
            rimID = car.RimID;
            baseCode = car.TextureID;
            timeStamp_temp = car.Timestamp;
        }
        
        //int.TryParse(colorID, out castcolorID);
        int.TryParse(rimID, out castrimID);

        if(!isoneTime)
        {
            isoneTime = true;
            checkTimestamp = timeStamp_temp;
            RimChanger(castrimID);
            Texture2D tex = base64Toimage(baseCode);
            FindpartsMaterials(tex);
        } else
        {
            if(timeStamp_temp == checkTimestamp)
            {
                Debug.Log("No update");
            } else
            {
                checkTimestamp = timeStamp_temp;
                RimChanger(castrimID);
                Texture2D tex = base64Toimage(baseCode);
                FindpartsMaterials(tex);
            }
        }

        //Reset Values
         //colorID = "";
         rimID = "";
         baseCode = "";
         //castcolorID = -1;
         castrimID = -1;
    }

    private void RimChanger(int castrimID)
    {
        if (castrimID != -1)
        {
            foreach (GameObject rim in rims)
            {
                rim.SetActive(false);
            }
            rims[castrimID].SetActive(true);
        }
    }

    private Texture2D base64Toimage(string baseCode)
    {
        //Texture Update
        byte[] imageBytes = Convert.FromBase64String(baseCode);
        Texture2D tex = new Texture2D(1024, 1024);
        tex.LoadImage(imageBytes);
        tex.Apply();
        return tex;

    }

    private void FindpartsMaterials(Texture2D texture)
    {
        foreach (GameObject carpart in carParts)
        {
            List<Material> mats = carpart.GetComponent<Renderer>().materials.ToList();
            foreach (Material mat in mats)
            {
                if (mat.name == "Texture Paint (Instance)" || mat.name == "CarPaint (Instance)")
                {
                    mat.SetTexture("_BaseMap", texture);
                }
            }
        } 
    }
}
