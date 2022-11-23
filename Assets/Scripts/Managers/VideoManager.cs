using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    [SerializeField] VideoSettingsData m_videoSettingsData;


    private void Start()
    {
        var res = m_videoSettingsData.Resolution;
        var mode = m_videoSettingsData.WindowMode;

        Screen.SetResolution(res.Width, res.Height, mode.Mode);
    }
}
