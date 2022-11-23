using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameSettingsController : MonoBehaviour
{
    [System.Serializable]
    public class TabData
    {
        public TabButtonController TabButton;
        public GameObject Panel;
    }


    [Header("Buttons")]
    [SerializeField] Button m_backButton;

    [Header("Tab Selection")]
    [SerializeField] TabData[] m_tabData;


    int m_selectedTabIndex;


    private void Awake()
    {
        m_backButton.onClick.AddListener(BackButtonOnClick);
    }


    private void OnEnable()
    {
        m_backButton.interactable = true;

        for (int i = 0; i < m_tabData.Length; i++)
        {
            var tabData = m_tabData[i];

            tabData.TabButton.TabIndex = i;
            tabData.TabButton.OnClick += SelectTab;

            tabData.TabButton.Deselect();
            tabData.Panel.SetActive(false);
        }

        if(m_tabData.Length > 0)
        {
            m_selectedTabIndex = -1;
            SelectTab(0);
        }
    }

    private void OnDisable()
    {
        m_backButton.interactable = false;

        foreach (var tabData in m_tabData)
        {
            tabData.TabButton.OnClick -= SelectTab;
        }
    }


    private void BackButtonOnClick()
    {
        gameObject.SetActive(false);
    }


    private void SelectTab(int tabIndex)
    {
        if (tabIndex == m_selectedTabIndex)
            return;

        if(m_selectedTabIndex >= 0)
        {
            var oldTabData = m_tabData[m_selectedTabIndex];
            oldTabData.TabButton.Deselect();
            oldTabData.Panel.SetActive(false);
        }

        if (tabIndex >= 0)
        {
            var newTabData = m_tabData[tabIndex];
            newTabData.TabButton.Select();
            newTabData.Panel.SetActive(true);
        }

        m_selectedTabIndex = tabIndex;
    }
}
