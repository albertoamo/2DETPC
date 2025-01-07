using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Count the number of lives of the player
public class PlayerHealthController : MonoBehaviour
{
    public int maxLives = 5; // Initial live number.
    public int lives; // Live number

    public float dmgDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if(lives > 0)
            lives = lives - 1;

        PlayerController hCtr = gameObject.GetComponent<PlayerController>();
        hCtr.cAnimator.SetBool("Hurt", true);
        StartCoroutine(HurtDelay());

        Debug.Log("The player has taken damage.");
    }

    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(dmgDelay);

        PlayerController hCtr = gameObject.GetComponent<PlayerController>();
        hCtr.cAnimator.SetBool("Hurt", false);
    }

    public void Regenerate()
    {
        lives = lives + 1;

        Debug.Log("The player has gained one hp.");
    }
}
