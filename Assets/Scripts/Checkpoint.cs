using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SerializeManager.INSTANCE.SaveGame();

        // I want the UI to show the saving icon
        // Apply some rotation or effect to the icon
        // Hide it, when finished.
        UILoadIcon loadicon = FindObjectOfType<UILoadIcon>();
        loadicon.LoadingPopup();
        enabled = false;

        Debug.Log("Saving the game");
    }
}
