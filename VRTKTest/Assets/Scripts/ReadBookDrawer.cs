using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBookDrawer : MonoBehaviour {

    //public GameObject Drawers;
    public GameObject book;

    bool bookInstantiated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!bookInstantiated)
        {
            Debug.Log("Hit Book");
            //RaycastHit hit;
            GameObject book_clone = Instantiate(book, book.transform.position, book.transform.rotation);
            book_clone.SetActive(true);
            bookInstantiated = true;
            this.gameObject.SetActive(false);
        }
        /*
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //GameObject book_clone = Instantiate(book, book.transform.position, book.transform.rotation);
            GameObject book_clone = Instantiate(book, hit.point, book.transform.rotation);
            book_clone.SetActive(true);
        }
        */
    }
}
