using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simplerotate : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float rotateSpeed = 200f;
    private float currentvalue;

    private bool rotate = false;

    // Use this for initialization
    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
    }

    public void startRotating()
    {
        rotate = true;
    }

    public void stopRotating()
    {
        rotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            currentvalue = currentvalue + (Time.deltaTime * rotateSpeed);

            //Debug.Log("currnet Value is " + currentvalue);

            rectComponent.transform.rotation = Quaternion.Euler(0f, -90f, -72f * (int)currentvalue);
        }
        else
        {
            rectComponent.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }
}