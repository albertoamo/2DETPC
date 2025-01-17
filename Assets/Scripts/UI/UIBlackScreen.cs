using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIBlackScreen : MonoBehaviour
{
    public static UIBlackScreen INSTANCE;

    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        INSTANCE = this;
    }

    public void FadeIn()
    {
        Debug.Log("FADE IN");
        image.DOFade(1, 1f).SetDelay(0.01f).SetEase(Ease.InQuart).OnComplete(() => 
        {
            Debug.Log("On complete");

        }); // A que valor, quiero que te pongas (alpha)
    }

    public void FadeOut()
    {
        Debug.Log("FADE OUT");
        image.DOFade(0, 1f).SetEase(Ease.OutQuart);
    }
}
