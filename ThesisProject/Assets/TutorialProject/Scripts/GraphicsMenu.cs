using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject playerObject;

    //[Header("Hello world")]

    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField] TMP_Text sensitivityValueTxt;
    [SerializeField] Slider mouseSensitivitySlider;

    Resolution[] resolutions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value;
        sensitivityValueTxt.text = newSensitivity.ToString();
        playerObject.GetComponent<PlayerLook>().mouseSensitivity = newSensitivity;
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void PopulateResDropDown()
    {
        int currentResIndex = 0;
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        for(int i = 0; i < resolutions.Length; i++)
        {
            options.Add("x" + resolutions[i].width + "y" + resolutions[i].height);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();

    }
    public void ChangeResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
