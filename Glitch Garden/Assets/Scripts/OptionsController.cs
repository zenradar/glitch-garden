using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public LevelManager levelManager;
    public Slider volumeSlider;
    public Slider difficultySlider;

    private MusicPlayer musicPlayer;

    // Use this for initialization
    void Start () {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update () {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        Debug.Log("SaveAndExit called");
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.loadLevel("01 Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 2.0f;
    }

    public string GetVolumeAsPercentage()
    {
        string volume = Mathf.Round(volumeSlider.value * 100).ToString();
        return volume;
    }

    public string GetDifficultyAsString()
    {
        float value = difficultySlider.value;

        switch(value.ToString())
        {
            case "1":
                return "Novice";
            case "2":
                return "Gardener";
            case "3":
            default:
                return "Expert";
        }
    }

}
