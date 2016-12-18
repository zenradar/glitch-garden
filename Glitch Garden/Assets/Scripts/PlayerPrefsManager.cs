using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master-volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level-unlocked-";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0.0f && volume <= 1.0f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1.0f && difficulty <= 3.0f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty value out of range. Difficulty is in range from 1 to 3.");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);  // use 1 for true
        } else
        {
            Debug.LogError("Trying to unlock level not in the build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            if (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1)
            {
                return true;
            }
        }
        else
        {
            Debug.LogError("Trying to query level not in the build order");
        }
        return false;
    }
}
