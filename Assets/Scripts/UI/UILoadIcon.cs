using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UILoadIcon : MonoBehaviour
{
    public Image icon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadingPopup()
    {
        icon.enabled = true;
        GetComponent<RectTransform>().DORotate(new Vector3(0, 0, -1720f), 2f, RotateMode.FastBeyond360).OnComplete(() =>
        {
            icon.enabled = false;
            GetComponent<RectTransform>().rotation = Quaternion.identity;
        });
    }
}
