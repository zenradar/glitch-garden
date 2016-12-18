using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.GetChild(0).transform.Rotate(0, 0, -720 * Time.deltaTime); // two full rotations per second around z axis
    }

}
