using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void loadLevel(string name)
    {
        Debug.Log("Level Load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        int indexOfSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(indexOfSceneToLoad);
    }

    public void quitRequest()
    {
        Debug.Log("Quit Request called");
        Application.Quit();
    }
}
