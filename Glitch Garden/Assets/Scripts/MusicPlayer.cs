using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    public AudioClip splashMusic, startMusic, optionsMusic, winMusic, loseMusic, level01Music, level02Music, level03Music;

    private AudioSource music;
    private AudioClip[] clip;

    // Use this for initialization
    void Start () {
        clip = new AudioClip[8];
        clip[0] = splashMusic;
        clip[1] = startMusic;
        clip[2] = optionsMusic;
        clip[3] = winMusic;
        clip[4] = loseMusic;
        clip[5] = level01Music;
        clip[6] = level02Music;
        clip[7] = level03Music;


        GameObject.DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        music.clip = clip[0];
        music.loop = true;
        music.volume = PlayerPrefsManager.GetMasterVolume(); 
        music.Play();

        // Jump to the start screen after 5 s.
        Invoke("StartGame", 5);
    }

    void StartGame()
    {
        SceneManager.sceneLoaded += PlaySceneMusic;
        SceneManager.LoadScene("01 Start");
    }

    void PlaySceneMusic(Scene scene, LoadSceneMode lsm)
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("MusicPlayer level: " + level);
        music.Stop();
        music.clip = clip[level];
        music.volume = PlayerPrefsManager.GetMasterVolume();
        music.Play();
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
