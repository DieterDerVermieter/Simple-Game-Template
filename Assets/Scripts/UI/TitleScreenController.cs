using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TitleScreenController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button m_playButton;
    [SerializeField] Button m_settingsButton;
    [SerializeField] Button m_quitButton;

    [Header("Popups")]
    [SerializeField] QuitPopupController m_quitPopupPrefab;

    [Header("Panels")]
    [SerializeField] GameObject m_settingsPanel;


    private void Awake()
    {
        m_playButton.onClick.AddListener(PlayButtonOnClick);
        m_settingsButton.onClick.AddListener(SettingsButtonOnClick);
        m_quitButton.onClick.AddListener(QuitButtonOnClick);
    }


    private void OnEnable()
    {
        m_settingsPanel.SetActive(false);

        SetButtonsInteractable(true);
    }

    private void OnDisable()
    {
        SetButtonsInteractable(false);
    }


    private void SetButtonsInteractable(bool state)
    {
        m_playButton.interactable = state;
        m_settingsButton.interactable = state;
        m_quitButton.interactable = state;
    }


    private void PlayButtonOnClick()
    {
    }

    private void SettingsButtonOnClick()
    {
        m_settingsPanel.SetActive(true);
    }

    private async void QuitButtonOnClick()
    {
        SetButtonsInteractable(false);

        var popup = Instantiate(m_quitPopupPrefab, transform);
        var result = await popup.DialogueResult();

        if (result)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
        else
        {
            Destroy(popup.gameObject);
            SetButtonsInteractable(true);
        }
    }
}
