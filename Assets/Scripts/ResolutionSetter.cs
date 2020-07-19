using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSetter : MonoBehaviour
{
    public int taskBarHeight = 50;
    public float screenRatio = 0.4618227f;

    private int resolutionHeight;
    private int resolutionWidth;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;

        Resolution[] resolutions = Screen.resolutions;

        resolutionHeight = 0;

        foreach (var res in resolutions)
        {
            if (res.height > resolutionHeight)
                resolutionHeight = res.height;
        }

        resolutionHeight -= taskBarHeight;

        resolutionWidth = GetWidthFromHeight(resolutionHeight);

        Screen.SetResolution(resolutionWidth, resolutionHeight, false);
    }

    private int GetWidthFromHeight(int height)
    {
        return (int) (height * screenRatio);
    }

    public void ChangeResolutionHeight(int height_change)
    {
        resolutionHeight += height_change;
        resolutionWidth = GetWidthFromHeight(resolutionHeight);
        Screen.SetResolution(resolutionWidth, resolutionHeight, false);
    }
}
