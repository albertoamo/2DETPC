using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        //AudioListener listener = FindObjectOfType<AudioListener>();
        AudioListener.volume = slider.value;
    }

}
