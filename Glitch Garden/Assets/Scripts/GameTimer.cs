using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float gameTime;
    public AudioClip winClip;

    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private GameObject levelCleared;
    private GameObject levelLost;
    private bool isEndOfLevel;

    // Use this for initialization
    void Start () {
        levelCleared = GameObject.Find("LevelCleared");
        levelCleared.SetActive(false);
        levelLost = GameObject.Find("LevelLost");
        levelLost.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();
        slider = GameObject.Find("Game Timer").GetComponent<Slider>();
        audioSource = GetComponent <AudioSource>();
        isEndOfLevel = false;
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = PlayTime();
        if(!isEndOfLevel)
        {
            if (slider.value == 1.0f)
            {
                isEndOfLevel = true;
                LevelCompleted();
            }

        }
    }

    private float PlayTime()
    {
        return Time.timeSinceLevelLoad / gameTime;
    }

    public void LevelLost()
    {
        if (!isEndOfLevel)
        {
            isEndOfLevel = true;
            audioSource.volume = 0.3f;
            audioSource.Play();
            levelLost.SetActive(true);
            Invoke("LoseLevel", audioSource.clip.length);
            DestroyAllActors();
        }
    }

    private void LevelCompleted()
    {
        // play QuestComplete
        audioSource.volume = 0.3f;
        audioSource.clip = winClip;
        audioSource.Play();

        DestroyAllActors();

        // Load next level
        levelCleared.SetActive(true);
        Invoke("NextLevel", audioSource.clip.length); 
    }

    private void DestroyAllActors()
    {
        GameObject coreGame = GameObject.Find("Core Game");
        Destroy(coreGame);
        GameObject[] actorArray = GameObject.FindGameObjectsWithTag("Actor");
        foreach(GameObject actor in actorArray)
        {
            Destroy(actor.gameObject);
        }
    }

    private void NextLevel ()
    {
        levelManager.LoadNextLevel();
    }

    private void LoseLevel()
    {
        levelManager.loadLevel("03 Lose");
    }

}
