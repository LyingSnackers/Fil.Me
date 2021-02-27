using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    public GameObject[] PrefabList;

    public static int cnt;

    // Start is called before the first frame update
    void Start()
    {
        LoadObj();
    }

    void LoadObj()
    {
        string path = Application.persistentDataPath + "/DataInfo.dat";
        PrefabList = GameObject.FindGameObjectsWithTag("SpritePrefab");

        string cnt_path = Application.persistentDataPath + "/CntInfo.dat";

        if (File.Exists(path))
        {
            List<ObjData> PrefabInfoes = new List<ObjData>();

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            PrefabInfoes = (List<ObjData>)formatter.Deserialize(file);
            if(PrefabInfoes.Count > 0)
            {
                Vector3 pos;

                for (int i = 0; i < PrefabInfoes.Count; i++)
                {
                    pos.x = PrefabInfoes[i].x_pos;
                    pos.y = PrefabInfoes[i].y_pos;
                    pos.z = PrefabInfoes[i].z_pos;

                    //Debug.Log(pos);
                    PrefabList[i].transform.position = pos;
                    //Instantiate(prefab, pos, Quaternion.identity);
                }
            }
            
        }

        if (File.Exists(cnt_path))
        {
            BinaryFormatter cnt_formatter = new BinaryFormatter();
            FileStream cnt_file = File.Open(cnt_path, FileMode.Open);
            cnt = (int)cnt_formatter.Deserialize(cnt_file);
            Debug.Log(cnt);
        }
        else
        {
            cnt = 0;
        }
    }

}
