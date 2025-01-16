using UnityEngine;
using UnityEngine.SceneManagement;

// This class manages the different scenes that compose a level
public class LevelManager : MonoBehaviour
{
    public static LevelManager INSTANCE;

    public string activeLevel;
    public string defaultLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        INSTANCE = this;
        LoadLevel(defaultLevel);
    }
    
    public void LoadLevel(string levelName)
    {
        Scene sceneActual = SceneManager.GetSceneByName(activeLevel);

        if(sceneActual != null && sceneActual.isLoaded)
            SceneManager.UnloadSceneAsync(activeLevel);

        Scene sceneToLoad = SceneManager.GetSceneByName(levelName);

        if (sceneToLoad != null)
        {
            SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
            activeLevel = levelName;
        }
    }

    public string GetActiveLevel()
    {
        return activeLevel;
    }
}
