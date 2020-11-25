using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite outlineSelectedSprite;
    public Sprite outlineNonSelectedSprite;
    public Image outline;

    public Sprite personSelectedSprite;
    public Sprite personNonSelectedSprite;
    public Image person;


    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.sprite = outlineSelectedSprite;
        person.sprite = personSelectedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.sprite = outlineNonSelectedSprite;
        person.sprite = personNonSelectedSprite;
    }
}
