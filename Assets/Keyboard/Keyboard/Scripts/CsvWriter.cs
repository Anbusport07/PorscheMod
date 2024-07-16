using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class CsvWriter : MonoBehaviour
{

    string filename = "";
    public TextMeshProUGUI namedata;
    public TextMeshProUGUI passworddata;
    public TextMeshProUGUI scoredata;
    public TextMeshProUGUI timedata;

    [System.Serializable]

    public class Player
    {
        public TextMeshProUGUI name;
        public TextMeshProUGUI password;
        public TextMeshProUGUI time;
        public TextMeshProUGUI score;
        //iscompleted?

    }

    [System.Serializable]
    public class Playerlist
    {
        public Player[] player;
    }

    public Playerlist myPlayerlist = new Playerlist();
    // Start is called before the first frame update
    void Start()
    {
        filename = Application.persistentDataPath + "/Exceldata.csv";
        print(namedata.text);
        print(passworddata.text);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        WriteCsv();
    //    }
        
    //}

    public void WriteCsv()
    {
        if (myPlayerlist.player.Length > 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Name ,Password , Score , Time");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i = 0; i < myPlayerlist.player.Length; i++)
            {
                //tw.WriteLine(myPlayerlist.player[i].name + "," + myPlayerlist.player[i].time + "," + myPlayerlist.player[i].score);
                tw.WriteLine($"{namedata.text},{passworddata.text},{scoredata.text},{timedata.text}");
            }
            tw.Close();
        }
    }
}
