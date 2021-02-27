using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjData
{
    public float x_pos;
    public float y_pos;
    public float z_pos;

    //public string encoded;

    public ObjData(float x, float y, float z)
    {
        this.x_pos = x;
        this.y_pos = y;
        this.z_pos = z;
    }
}
