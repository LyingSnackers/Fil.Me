using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MakeImgbox : MonoBehaviour
{
    
    private GameObject[] ImgBoxprefab;

    [SerializeField]
    GameObject ErrorPanel;

    public void SpawnBox()
    {
        int pcnt = LoadData.cnt;
        ImgBoxprefab = GameObject.FindGameObjectsWithTag("SpritePrefab");
        try
        {
            ImgBoxprefab[pcnt].transform.position = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
            LoadData.cnt++;
        }
        catch
        {
            ErrorPanel.SetActive(true);
            //Debug.Log("허용 갯수를 초과했습니다.");
        }
        


        /*if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(ImgBoxprefab, touchPos, Quaternion.identity);
            }
        }*/

        //Instantiate(ImgBoxprefab, Vector3.zero, Quaternion.identity);
        //ImgBoxprefab.tag = "SpritePrefab";
    }
}
