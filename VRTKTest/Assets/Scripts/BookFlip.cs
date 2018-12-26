using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BookFlip : MonoBehaviour {

    public GameObject headset;

    VRTK_ControllerEvents events;
    VRTK_Pointer pointer;
    MegaBookBuilder book;

    bool touched = false;
    float dragsensi = 0.4f;

    Vector2 axis = new Vector2(0, 0);

    // Use this for initialization
    void Start () {
        pointer = headset.GetComponent<VRTK_Pointer>();
        events = GetComponent<VRTK_ControllerEvents>();
        events.TouchpadTouchStart += new ControllerInteractionEventHandler(DoTouchpadTouched);
        events.TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadUntouched);
    }

    private void DoTouchpadTouched(object sender, ControllerInteractionEventArgs e)
    {
        touched = true;
        axis = e.touchpadAxis;
    }

    private void DoTouchpadUntouched(object sender, ControllerInteractionEventArgs e)
    {
        touched = false;
    }

    // Update is called once per frame
    void Update () {
        RaycastHit Hit = pointer.pointerRenderer.GetDestinationHit();

        if (Hit.collider != null)
        {
            Debug.Log("Hit " + Hit.collider.gameObject.name);
            if (Hit.collider.gameObject.name == "Table Book" && touched)
            {
                book = Hit.collider.gameObject.GetComponent<MegaBookBuilder>();
                //float alpha = book.bookalpha + (axis.x * book.dragsensi);
                float change_page = book.GetPage() + (-1 * axis.x * dragsensi);
                //book.bookalpha = Mathf.Clamp(alpha, 0.0f, 100.0f);
                book.SetPage(change_page, false);
            }
        }
    }
}
