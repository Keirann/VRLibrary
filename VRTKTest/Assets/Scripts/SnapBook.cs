using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SnapBook : VRTK_SnapDropZone {

    public GameObject book;
    public GameObject[] canvases;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnObjectSnappedToDropZone(SnapDropZoneEventArgs e)
    {
        base.OnObjectSnappedToDropZone(e);
        GameObject prev_book = e.snappedObject;
        prev_book.SetActive(false);
        UnsnapObject();
        //currentSnappedObject = null;
        //GameObject book_clone = Instantiate(book, book.transform.position, book.transform.rotation);
        //book.SetActive(true);
        book.transform.position = new Vector3(-1.29f, 1.293f, -1.046f);
        canvases[0].SetActive(false);
        canvases[1].SetActive(true);
        //Debug.Log(book_clone.name);
    }
}
