using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;
    private int currentQualityIndex = 0;
    private bool isFullScreen = false;

    private void Start()
    {
        FillDropdownResolutions();
    }

    public void SetQuality(int qualityIndex)
    {
        currentQualityIndex = qualityIndex;
    }

    public void SetResolution(int resolutionIndex)
    {
        currentResolutionIndex = resolutionIndex;
    }

    public void ChangeFullScreenMode(bool value)
    {
        isFullScreen = value;
    }

    private void FillDropdownResolutions()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution))
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SaveChanges()
    {
        QualitySettings.SetQualityLevel(currentQualityIndex);
        Screen.SetResolution(Screen.resolutions[currentResolutionIndex].width, Screen.resolutions[currentResolutionIndex].height, isFullScreen);
        Screen.fullScreen = isFullScreen;
    }
}
