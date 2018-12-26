using UnityEngine;
using VRTK;
using System.Collections;

public class DestroyBookOnFloor : MonoBehaviour
{
    public GameObject floor;

    void Start() { }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == floor)
        {
            Destroy(this.gameObject);
        }
    }
}