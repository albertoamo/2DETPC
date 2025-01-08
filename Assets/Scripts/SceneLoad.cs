using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    //public string SceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.UnloadSceneAsync("spmap_gp1");
        SceneManager.LoadScene("spmap_gp2", LoadSceneMode.Additive);
    }
}
