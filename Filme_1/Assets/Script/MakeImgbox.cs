using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeImgbox : MonoBehaviour
{
    [SerializeField]
    private GameObject ImgBoxprefab;

    public void SpawnBox()
    {
        /*if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(ImgBoxprefab, touchPos, Quaternion.identity);
            }
        }*/

        Instantiate(ImgBoxprefab, Vector2.zero, Quaternion.identity);
    }
}
