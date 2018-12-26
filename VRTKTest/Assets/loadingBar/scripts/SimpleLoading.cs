using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleLoading : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float rotateSpeed = 200f;
    bool rotate = false;

    // Use this for initialization
    void Start () {
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
    void Update () {
        if (rotate)
        {
            rectComponent.Rotate(0f, 0f, -(rotateSpeed * Time.deltaTime));
        }
        else
        {
            rectComponent.Rotate(0f, 0f, 0f);
        }
    }
}
