using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInPanel : MonoBehaviour {

    public float fadeTime = 5.0f;

    private Image fadePanel;
    private Color fadeColor = Color.black;

	// Use this for initialization
	void Start () {
        fadePanel = GetComponent<Image>();   	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeTime)
        {
            //float deltaTime = fadeTime - Time.timeSinceLevelLoad;
            float fadeBy = 1 - (Time.timeSinceLevelLoad / fadeTime);
            fadeColor.a = fadeBy;
            fadePanel.color = fadeColor;
        } else
        {
            gameObject.SetActive(false);
        }
	}
}
