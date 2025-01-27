using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler// required interface when using the OnPointerEnter method.
{
    public AudioClip clip;

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        AudioManager.INSTANCE.source.PlayOneShot(clip);
    }
}