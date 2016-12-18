using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int starCost = 50;

    private StarDisplay starDisplay;

    // Use this for initialization
    void Start () {
        starDisplay = FindObjectOfType<StarDisplay>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
