using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractPage : MonoBehaviour {

    public GameObject rightCollider;
    public GameObject leftCollider;
    public GameObject centerCollider;
    public GameObject controller;

    VRTK_Pointer pointer;
    MegaBookBuilder book;

    int pages;
    float alphaPerPage;
    float initial_alpha;
    float dragsensi = 0.5f;
    float distance_between_colliders = 5.0f;
    float rightCollider_z = 8.5f;
    float leftCollider_z = 3.5f;

    bool centerColliderHit = false;
    bool isFlipping = false;
    int rightToLeft = 1;

    // Use this for initialization
    void Start () {
        book = GetComponent<MegaBookBuilder>();
        pointer = controller.GetComponent<VRTK_Pointer>();

        pages = book.GetPageCount();
        alphaPerPage = 1;
        initial_alpha = book.GetPage();
    }
	
	// Update is called once per frame
	void Update () {

        if (pointer.IsActivationButtonPressed())
        {
            RaycastHit Hit = pointer.pointerRenderer.GetDestinationHit();
            if (Hit.collider != null)
            {
                if (Hit.collider.gameObject == rightCollider)
                {
                    centerCollider.SetActive(true);
                    setNearestAlpha();
                    rightToLeft = 1;
                    initial_alpha = book.GetPage();
                    Debug.Log("Right Collider - z axis = " + Hit.point.z);
                }

                if (Hit.collider.gameObject == centerCollider)
                {
                    Vector3 point = Hit.point;
                    float z_axis = point.z;
                    if(rightToLeft == -1)
                    {
                        z_axis = (z_axis - leftCollider_z);
                    }
                    else
                    {
                        z_axis = (rightCollider_z - z_axis);
                    }
                    float change_alpha = rightToLeft * alphaPerPage * z_axis / distance_between_colliders;
                    Debug.Log(change_alpha);
                    float alpha = initial_alpha + change_alpha;
                    book.SetPage(alpha, true);
                    Debug.Log("Current Book Page " + book.GetPage());
                }

                if (Hit.collider.gameObject == leftCollider)
                {
                    centerCollider.SetActive(true);
                    setNearestAlpha();
                    rightToLeft = -1;
                    initial_alpha = book.GetPage();
                    Debug.Log("Left Collider - z axis = " + Hit.point.z);
                }
            }
        }
        else
        {
            centerCollider.SetActive(false);
            setNearestAlpha();
            /*
            float page = book.GetPage();
            float upPage = Mathf.Ceil(page);
            float downPage = Mathf.Floor(page);
            if(Mathf.Abs(page - upPage) < Mathf.Abs(page - downPage))
            {
                book.SetPage(upPage, false);
            }
            else
            {
                book.SetPage(downPage, false);
            }
            
            float min_distance = 1000;
            float best_alpha = 1000;
            float book_alpha = book.bookalpha;
            for(int i = 0; i <= 100; i += (int)alphaPerPage)
            {
                if(Mathf.Abs(book_alpha - i) < min_distance)
                {
                    min_distance = Mathf.Abs(book_alpha - i);
                    best_alpha = i;
                }
            }
            book.bookalpha = best_alpha;
            */
        }
    }

    void setNearestAlpha()
    {
        float page = book.GetPage();
        float upPage = Mathf.Ceil(page);
        float downPage = Mathf.Floor(page);
        if (Mathf.Abs(page - upPage) < Mathf.Abs(page - downPage))
        {
            book.SetPage(upPage, false);
        }
        else
        {
            book.SetPage(downPage, false);
        }
    }
}
