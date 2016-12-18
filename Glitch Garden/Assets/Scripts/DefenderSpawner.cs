using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        Vector2 position = SnapToGrid(CalculateWorldPointOfMouseClick());
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(defender, position);
        } else
        {
            // TODO: play a short buzz audio to indicate lack of currency 
        }
    }

    private void SpawnDefender(GameObject defender, Vector2 position)
    {
        GameObject newDefender = Instantiate(defender, position, Quaternion.identity);
        GameObject parent = GameObject.Find("Defenders");
        newDefender.transform.parent = parent.transform;

    }

    private Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10.0f;

        Vector3 triplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPoint = myCamera.ScreenToWorldPoint(triplet);
        return worldPoint;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float snapX, snapY;

        snapX = Mathf.RoundToInt(rawWorldPosition.x);
        snapY = Mathf.RoundToInt(rawWorldPosition.y);

        return new Vector2(snapX, snapY);

    }
}
