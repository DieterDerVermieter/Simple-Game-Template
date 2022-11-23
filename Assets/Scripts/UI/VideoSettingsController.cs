using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class VideoSettingsController : MonoBehaviour
{
    [SerializeField] VideoSettingsData m_videoSettingsData;

    [Header("Resolution")]
    [SerializeField] TMP_Dropdown m_resolutionDropdown;

    [Header("Window Mode")]
    [SerializeField] TMP_Dropdown m_windowModeDropdown;


    private void Awake()
    {
        m_resolutionDropdown.ClearOptions();
        m_resolutionDropdown.AddOptions(m_videoSettingsData.PossibleResolutions.Select(resolutionData => resolutionData.DisplayName).ToList());

        m_windowModeDropdown.ClearOptions();
        m_windowModeDropdown.AddOptions(m_videoSettingsData.PossibleWindowModes.Select(windowModeData => windowModeData.DisplayName).ToList());

        MatchSettingsData();

        m_resolutionDropdown.onValueChanged.AddListener(ResolutionDropdownOnValueChanged);
        m_windowModeDropdown.onValueChanged.AddListener(WindowModeDropdownOnValueChanged);
    }


    private void OnEnable()
    {
        m_resolutionDropdown.interactable = true;
        m_windowModeDropdown.interactable = true;
    }

    private void OnDisable()
    {
        m_resolutionDropdown.interactable = false;
        m_windowModeDropdown.interactable = false;
    }


    private void MatchSettingsData()
    {
        m_resolutionDropdown.value = m_videoSettingsData.ResolutionIndex;
        m_windowModeDropdown.value = m_videoSettingsData.WindowModeIndex;
    }


    private void ResolutionDropdownOnValueChanged(int value)
    {
        m_videoSettingsData.ResolutionIndex = value;

        var res = m_videoSettingsData.Resolution;
        var mode = m_videoSettingsData.WindowMode;

        Screen.SetResolution(res.Width, res.Height, mode.Mode);
    }

    private void WindowModeDropdownOnValueChanged(int value)
    {
        m_videoSettingsData.WindowModeIndex = value;

        Screen.fullScreenMode = m_videoSettingsData.WindowMode.Mode;
    }
}
