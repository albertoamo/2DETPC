using UnityEngine;

public class UIBlackScreen : MonoBehaviour
{
    public static UIBlackScreen INSTANCE;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        INSTANCE = this;
    }

    public void FadeIn()
    {
        Debug.Log("FADE IN");
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
    }

    public void FadeOut()
    {
        Debug.Log("FADE OUT");
        animator.SetBool("FadeOut", true);
        animator.SetBool("FadeIn", false);
    }
}
