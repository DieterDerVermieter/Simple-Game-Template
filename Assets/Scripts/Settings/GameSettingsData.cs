using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameSettingsData : ScriptableObject
{
    public bool globalSound = true;
    public float globalVolume = 1;

    public Vector2 resolution = new Vector2(960, 540);
    public FullScreenMode fullScreenMode = FullScreenMode.Windowed;
}
