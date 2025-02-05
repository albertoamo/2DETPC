using UnityEngine;

public class SerializeManager : MonoBehaviour
{
    public static SerializeManager INSTANCE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        INSTANCE = this;
    }

    public void LoadGame()
    {
        // Save current level
        string level = PlayerPrefs.GetString("level");

        LevelManager.INSTANCE.LoadLevel(level, true);
    }

    public void LoadGameData()
    {
        // Load all the serialized data into runtime memory
        float posx = PlayerPrefs.GetFloat("posx");
        float posy = PlayerPrefs.GetFloat("posy");
        float posz = PlayerPrefs.GetFloat("posz");

        int lives = PlayerPrefs.GetInt("health");

        PlayerController.INSTANCE.transform.position = new Vector3(posx, posy, posz);
        PlayerController.INSTANCE.cHealth.lives = lives;

        Debug.Log("Loading scene data");
    }

    public void SaveGame()
    {
        // Save all the runtime data into serialized memory
        // Save position, save health, inventory, 
        PlayerController hCtr = PlayerController.INSTANCE;

        PlayerPrefs.SetFloat("posx", hCtr.transform.position.x);
        PlayerPrefs.SetFloat("posy", hCtr.transform.position.y);
        PlayerPrefs.SetFloat("posz", hCtr.transform.position.z);

        PlayerPrefs.SetInt("health", hCtr.cHealth.lives);

        // Save current level
        PlayerPrefs.SetString("level", LevelManager.INSTANCE.activeLevel);

        // Save objects state

        // Save the data into file
        PlayerPrefs.Save();
    }
}
