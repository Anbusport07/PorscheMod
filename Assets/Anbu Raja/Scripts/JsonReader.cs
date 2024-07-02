using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using System.Threading.Tasks;
using System.Collections.Generic;

using static JsonReader;
using System.Threading;
using System.Linq;

public class JsonReader : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> carParts;
    [SerializeField]
    private GameObject carModel;
    [SerializeField]
    private Texture[] carTextures;
    [SerializeField]
    private GameObject[] rims;

    public static JsonReader Instance;

    private static float checkInterval = 5f;
 
    [SerializeField]
    private string URL = "";

    //[SerializeField]
   // private string baseCode = "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";

    private string tempURL;
    //private Material carPaintmat;
    //private Material TexturePaint;
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
        //carPaintmat = carModel.GetComponent<Renderer>().materials[15];
       // TexturePaint = carModel.GetComponent<Renderer>().materials[14];
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
