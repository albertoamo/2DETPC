
using System.Collections;
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
        LoadLevel(defaultLevel, false);
    }
    
    public void LoadLevel(string levelName, bool loadGame = false)
    {
        StartCoroutine(LoadLevelAsync(levelName, loadGame));
    }

    IEnumerator LoadLevelAsync(string levelName, bool loadGame)
    {
        GameStateManager.INSTANCE.ChangeState(GameStateManager.GameState.LOAD);

        UIBlackScreen.INSTANCE.FadeIn();
        {
            Scene sceneActual = SceneManager.GetSceneByName(activeLevel);

            if (sceneActual != null && sceneActual.isLoaded)
                SceneManager.UnloadSceneAsync(activeLevel);

            Scene sceneToLoad = SceneManager.GetSceneByName(levelName);

            yield return new WaitForSecondsRealtime(1);

            if (sceneToLoad != null)
            {
                SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
                activeLevel = levelName;
            }
        }

        if (loadGame)
        {
            yield return new WaitForSecondsRealtime(1);
            SerializeManager.INSTANCE.LoadGameData();
        }

        UIBlackScreen.INSTANCE.FadeOut();
    }

    public string GetActiveLevel()
    {
        return activeLevel;
    }
}
