using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

    private GameObject parent;

	// Use this for initialization
	void Start () {
        parent = gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        foreach(GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    private void Spawn(GameObject myGameObject)
    {
        Vector2 position = parent.transform.position;
        GameObject attacker = Instantiate(myGameObject, position, Quaternion.identity);
        attacker.transform.parent = parent.transform;
    } 

    private bool isTimeToSpawn(GameObject myGameObject)
    {
        Attacker attacker = myGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;  // divided across the five lanes.

        return Random.value < threshold;
    }

}
