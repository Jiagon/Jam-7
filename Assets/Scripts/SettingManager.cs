using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour {
	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Dropdown antialiasingDropdown;
	public Dropdown vSyncDropdown;
	public Slider musicVolumeSlider;
	public Button applyButton;
    public GameObject entireMenu;

    public bool visible;

	public AudioSource musicSource;
	public Resolution[] resolutions;
	public GameSettings gameSettings;

    void OnEnable()
	{
		gameSettings = new GameSettings ();

		fullscreenToggle.onValueChanged.AddListener (delegate { OnFullScreenToggle(); });
		resolutionDropdown.onValueChanged.AddListener (delegate { OnResolutionChange(); });
		textureQualityDropdown.onValueChanged.AddListener (delegate { OnTextureQualityChange(); });
		antialiasingDropdown.onValueChanged.AddListener (delegate { OnAntialiasingChange(); });
		vSyncDropdown.onValueChanged.AddListener (delegate { OnVSyncChange(); });
		musicVolumeSlider.onValueChanged.AddListener (delegate { OnMusicVolumeChange(); });
		applyButton.onClick.AddListener (delegate {OnApplyButtonClick ();});

		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) 
		{
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
		}

		LoadSettings ();
	}

    public void Start()
    {
        visible = false;
        entireMenu.SetActive(false);
    }
    public void OnFullScreenToggle()
	{
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
		Debug.Log ("Fullscreen?");
	}

	public void OnResolutionChange()
	{
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.resolutionIndex = resolutionDropdown.value;
	}
	public void OnTextureQualityChange()
	{
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
	}
	public void OnAntialiasingChange()
	{
		QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow (2f, antialiasingDropdown.value);
	}
	public void OnVSyncChange()
	{
		QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
	}
	public void OnMusicVolumeChange()
	{
		musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
	}

	public void OnApplyButtonClick()
	{
		SaveSettings ();
	}

	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson (gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsonData);
	}
	public void LoadSettings()
	{
		gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gameSettings.Json"));

		musicVolumeSlider.value = gameSettings.musicVolume;
		antialiasingDropdown.value = gameSettings.antialiasing;
		vSyncDropdown.value = gameSettings.vSync;
		textureQualityDropdown.value = gameSettings.textureQuality;
		resolutionDropdown.value = gameSettings.resolutionIndex;
		fullscreenToggle.isOn = gameSettings.fullscreen;
		Screen.fullScreen = gameSettings.fullscreen;
			
		resolutionDropdown.RefreshShownValue ();
	}
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            entireMenu.SetActive(!visible);
            visible = !visible;
        }   
    }
}


