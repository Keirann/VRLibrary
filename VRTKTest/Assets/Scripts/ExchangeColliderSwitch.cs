using UnityEngine;
using VRTK;
using System.Collections;

public class ExchangeColliderSwitch : MonoBehaviour
{
    public GameObject exchangeCollider;

    void Start()

    {   
        //subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 

        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
    }



    //this object has been grabbed.. so do what ever is in the code.. 

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)

    {
        if (!exchangeCollider.activeSelf)
        {
            exchangeCollider.SetActive(true);
        }
    }

}