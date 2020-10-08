﻿/// Base script from here: Creating a Custom Tab System in Unity - https://youtu.be/211t6r12XPQ

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    [HideInInspector]
    public Image background;

    public delegate void OnTabSelected(GameObject gameObject);
    public static event OnTabSelected OnTabSelectedEvent;

    public delegate void OnTabDeselected(GameObject gameObject);
    public static event OnTabDeselected OnTabDeselectedEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }


    public void Select()
    {
        OnTabSelectedEvent?.Invoke(this.gameObject);
    }
    public void Deselect()
    {
        OnTabDeselectedEvent?.Invoke(this.gameObject);
    }
}
