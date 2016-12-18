using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE };

    private Text text;
    private int score;
     
	// Use this for initialization
	void Start () {
        score = 100;
        text = GetComponent<Text>();
        UpdateDisplay(); 	
	}
	
    public void AddStars(int amount)
    {
        score += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        Debug.Log("UseStars called with " + amount);
        if (score >= amount)
        {
            score -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        text.text = score.ToString();
    }
}
