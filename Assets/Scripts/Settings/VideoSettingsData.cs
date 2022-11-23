using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VideoSettingsData : ScriptableObject
{
    [System.Serializable]
    public class ResolutionData : ISerializationCallbackReceiver
    {
        public string DisplayName = "1080p (16:9)";
        public int Width = 1920;
        public int Height = 1080;

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            var f = (float)Height / Width;

            int w = 16;
            int h = (int)(w * f);

            int d = 8;
            int count = 0;

            while(d > 1 && count < 10)
            {
                if (w % d == 0 && h % d == 0)
                {
                    w /= d;
                    h /= d;
                }
                else
                {
                    d--;
                }
                count++;
            }

            DisplayName = $"{Width}x{Height} ({w}:{h})";
        }
    }

    public ResolutionData Resolution => PossibleResolutions[ResolutionIndex];
    public ResolutionData[] PossibleResolutions;
    public int ResolutionIndex;


    [System.Serializable]
    public class WindowModeData
    {
        public string DisplayName = "Windowed";
        public FullScreenMode Mode = FullScreenMode.Windowed;
    }

    public WindowModeData WindowMode => PossibleWindowModes[WindowModeIndex];
    public WindowModeData[] PossibleWindowModes;
    public int WindowModeIndex;
}
