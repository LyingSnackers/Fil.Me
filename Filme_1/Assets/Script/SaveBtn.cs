using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveBtn : MonoBehaviour
{
    public GameObject[] PrefabList;
    public ObjData objData;
    public static List<ObjData> PrefabInfoes = new List<ObjData>();

    public void SaveInfo()
    {
        PrefabList = GameObject.FindGameObjectsWithTag("SpritePrefab");
        for (int i=0; i<PrefabList.Length; i++)
        {
            float x = PrefabList[i].transform.position.x;
            float y = PrefabList[i].transform.position.y;
            float z = PrefabList[i].transform.position.z;
            PrefabInfoes.Add(new ObjData(x, y, z));
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/DataInfo.dat");
        formatter.Serialize(file, PrefabInfoes);

        BinaryFormatter cnt_formatter = new BinaryFormatter();
        FileStream cnt_file = File.Create(Application.persistentDataPath + "/CntInfo.dat");
        cnt_formatter.Serialize(cnt_file, LoadData.cnt);

        Debug.Log("Save");
        file.Close();
        cnt_file.Close();
    }

    /*
    public void SaveBg()
    {
        ScreenCapture.CaptureScreenshot(Application.persistentDataPath+ "/Filme_1.png");
        Debug.Log("capture");
    }
    */
}
