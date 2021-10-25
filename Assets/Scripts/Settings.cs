using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    public Dropdown Change_color_dropdown;

    Resolution[] resolutions;

    public ColorBlindFilter Camera_color;


    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void Change_color()
    {
        if (Change_color_dropdown.value==0)
        {
            Camera_color.mode = ColorBlindMode.Normal;
        }
        if(Change_color_dropdown.value == 1)
        {
            Camera_color.mode = ColorBlindMode.Protanopia;
        }
        if (Change_color_dropdown.value == 2)
        {
            Camera_color.mode = ColorBlindMode.Deuteranopia;
        }
        if (Change_color_dropdown.value == 3)
        {
            Camera_color.mode = ColorBlindMode.Tritanopia;
        }
       

    }
}
