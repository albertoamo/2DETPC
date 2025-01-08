using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Utilizar los diferentes sprites
// Cuando pierda una vida, el sprite se oscurezca

public class UIHealth : MonoBehaviour
{
    public Image[] cherry;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restar una vida
    public void UpdateHealth(int lives)
    {
        for (int i = 0; i < cherry.Length; i++)
        {
            if (i < (lives))
                cherry[i].color = Color.white;
            else
                cherry[i].color = Color.black;
        }
    }
}
