﻿/// Base script from here: Creating a Custom Tab System in Unity - https://youtu.be/211t6r12XPQ

using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    public PanelGroup panelGroup;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }


    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHover;
        }

    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }
    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }

        selectedTab = button;

        selectedTab.Select();

        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        //for (int i = 0; i < objectsToSwap.Count; i++)
        //{
        //    if (i == index) objectsToSwap[i].SetActive(true);
        //    else objectsToSwap[i].SetActive(false);

        //}

        if(panelGroup != null)
        {
            panelGroup.SetPageIndex(index);
        }

    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) continue;
            button.background.color = tabIdle;
        }
    }
}
