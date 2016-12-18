using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;

    public GameObject defender;

    private Button[] buttonArray;
    private Text costText;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (!costText) { Debug.LogWarning(name + " has no cost text"); }
        costText.text = defender.GetComponent<Defender>().starCost.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        foreach (Button button in buttonArray)
        {
            // a nice darkened red to show some detail in the dark
            button.GetComponent<SpriteRenderer>().color = new Color32(0x69, 0x1A, 0x1A, 0xFF);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defender;
    }

}
