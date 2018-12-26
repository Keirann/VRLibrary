using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingcolorful : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.0f;
    public GameObject book;
    public GameObject[] canvases;

    bool rotate = false;

    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
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
        if (imageComp.fillAmount != 1f)
        {
            if (rotate)
            {
                imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            }
            else
            {
                imageComp.fillAmount = 0.0f;
            }

        }
        else
        {
            GameObject cloned_book = Instantiate(book, book.transform.position, book.transform.rotation);
            cloned_book.SetActive(true);
            cloned_book.name = book.name;
            imageComp.fillAmount = 0.0f;
            canvases[0].SetActive(false);
            canvases[1].SetActive(true);

        }
    }
}
