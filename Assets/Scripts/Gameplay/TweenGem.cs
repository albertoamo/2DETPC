using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TweenGem : MonoBehaviour
{
    public float height = 0.5f;
    public float timelapse = 1.5f;
    public Ease easing;

    public SpriteRenderer gemImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlatformMove();
    }

    void PlatformMove()
    {
        gemImage.DOColor(Color.yellow, timelapse);

        transform.DOLocalMoveY(height, timelapse).SetEase(easing).OnComplete(() =>
        {
            gemImage.DOColor(Color.white, timelapse);

            transform.DOLocalMoveY(-height, timelapse).SetEase(easing).OnComplete(() =>
            {
                PlatformMove();
            });
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.transform.SetParent(this.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
