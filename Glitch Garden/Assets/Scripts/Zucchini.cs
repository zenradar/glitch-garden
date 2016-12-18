using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zucchini : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.GetChild(0).transform.Rotate(0, 0, -540 * Time.deltaTime); // one and a half rotations per second around z axis
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // placeholder
    }

}
