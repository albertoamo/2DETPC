using DG.Tweening;
using UnityEngine;

public class TweenPlatform : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.DOMove(new Vector3(8.5f, 0, 0), 5f);
        transform.DOLocalMove(waypoint2.position, 5f).SetEase(Ease.Linear);

        PlayerController player = FindObjectOfType<PlayerController>();
        player.transform.SetParent(this.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // TO-DO
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
