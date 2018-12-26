using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeBooks : MonoBehaviour {

    public GameObject Batman;
    public GameObject WalkingDead;
    public GameObject EmptyBook;
    public GameObject[] canvases;

    string current_book = "Empty";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Exchanger Hit " + other.gameObject.name);
        Vector3 new_pos = new Vector3(-1.03f, 1.618f, 6.11f);
        Vector3 old_pos = new Vector3(-100f, 1.618f, 6.11f);
        if (other.gameObject.name == "Book 1")
        {
            canvases[0].SetActive(false);
            canvases[1].SetActive(true);
            Destroy(other.gameObject);
            if (current_book == "Empty")
            {
                EmptyBook.transform.position = old_pos;
            } else if (current_book == "Walking")
            {
                WalkingDead.transform.position = old_pos;
            }
            Batman.transform.position = new_pos;
            current_book = "Batman";
            this.gameObject.SetActive(false);
        }
        else if(other.gameObject.name == "Book 2")
        {
            canvases[0].SetActive(false);
            canvases[1].SetActive(true);
            Destroy(other.gameObject);
            if (current_book == "Empty")
            {
                EmptyBook.transform.position = old_pos;
            }
            else if (current_book == "Batman")
            {
                Batman.transform.position = old_pos;
            }
            WalkingDead.transform.position = new_pos;
            current_book = "Walking";
            this.gameObject.SetActive(false);
        }
    }
}
