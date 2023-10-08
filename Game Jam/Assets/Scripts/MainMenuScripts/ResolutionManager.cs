using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    void Start()
    {
        // Set the initial resolution to the highest available resolution
        Resolution highestResolution = Screen.resolutions.OrderByDescending(res => res.width).ThenByDescending(res => res.height).First();
        Screen.SetResolution(highestResolution.width, highestResolution.height, Screen.fullScreen);

        // Populate dropdown options with available resolutions
        PopulateDropdown();
    }

    void PopulateDropdown()
    {
        resolutionDropdown.ClearOptions();

        // Get available resolutions and sort them by width and height
        Resolution[] resolutions = Screen.resolutions.OrderByDescending(res => res.width).ThenByDescending(res => res.height).ToArray();

        // Populate dropdown options with resolution strings
        foreach (var resolution in resolutions)
        {
            string resolutionString = resolution.width + "x" + resolution.height;
            // Avoid duplicate resolutions
            if (!resolutionDropdown.options.Any(option => option.text == resolutionString))
            {
                resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionString));
            }
        }

        resolutionDropdown.RefreshShownValue();
    }

    public void OnResolutionDropdownChanged(int index)
    {
        // Get the selected resolution option
        string selectedResolution = resolutionDropdown.options[index].text;

        // Parse the selected resolution
        string[] resolutionParts = selectedResolution.Split('x');
        int width = int.Parse(resolutionParts[0]);
        int height = int.Parse(resolutionParts[1]);

        // Change the screen resolution
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
