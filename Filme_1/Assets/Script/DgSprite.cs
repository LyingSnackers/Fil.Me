using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgSprite : MonoBehaviour
{
    private bool isDragging;

    [SerializeField]
    GameObject prefab;
    


    public void OnMouseDown()
    {
        Debug.Log("OMD");
        isDragging = true;
    }

    public void OnMouseUp()
    {
        Debug.Log("OMU");
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Debug.Log("Dragging");
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //3로 하면 z축이 카메라랑 같아짐
            transform.Translate(mousePos);
        }
    }
}
