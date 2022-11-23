using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AudioSettingsController : MonoBehaviour
{
    [SerializeField] AudioSettingsData m_audioSettingsData;

    [Header("Global Volume")]
    [SerializeField] TMP_Text m_globalVolumeText;
    [SerializeField] Slider m_globalVolumeSlider;
    [SerializeField] Toggle m_globalVolumeToggle;


    private void Awake()
    {
        MatchSettingsData();

        m_globalVolumeSlider.onValueChanged.AddListener(GlobalVolumeSliderOnValueChanged);
        m_globalVolumeToggle.onValueChanged.AddListener(GlobalVolumeToggleOnValueChanged);
    }


    private void OnEnable()
    {
        m_globalVolumeSlider.interactable = true;
        m_globalVolumeToggle.interactable = true;
    }

    private void OnDisable()
    {
        m_globalVolumeSlider.interactable = false;
        m_globalVolumeToggle.interactable = false;
    }


    private void MatchSettingsData()
    {
        var volumePercent = m_audioSettingsData.GlobalVolume * 100;
        m_globalVolumeText.text = $"{volumePercent}";
        m_globalVolumeSlider.value = volumePercent;
        m_globalVolumeToggle.isOn = m_audioSettingsData.GlobalVolumeOn;
    }


    private void GlobalVolumeSliderOnValueChanged(float value)
    {
        // Debug.Log($"GlobalVolumeSlider: value={value}");

        m_globalVolumeText.text = $"{value}";
        m_audioSettingsData.GlobalVolume = value / 100;
        m_globalVolumeToggle.isOn = true;
    }

    private void GlobalVolumeToggleOnValueChanged(bool state)
    {
        // Debug.Log($"GlobalVolumeToggle: state={state}");

        m_audioSettingsData.GlobalVolumeOn = state;
    }
}
