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
        // Load all the serialized data into runtime memory
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
