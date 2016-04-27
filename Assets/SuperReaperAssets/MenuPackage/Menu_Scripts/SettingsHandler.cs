using UnityEngine;
using System;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour {
    [SerializeField]
    private Slider masterVolumeSlider;

    [SerializeField]
    private Toggle vSyncToggle;

    // Use this for initialization.
    void Start () {
        Application.targetFrameRate = 300;
        VolumeHandler(true);
        VsyncHandler(true);
    }

    // Called when the V-sync toggle is changed.
    public void VsyncHandler (bool isStart) {
        // 0 = don't sync.
        // 1 = Sync every vBlank.
        //QualitySettings.vSyncCount = number;

        if (isStart)
        {
            if (!PlayerPrefs.HasKey("vSyncCount"))
            {
                PlayerPrefs.SetInt("vSyncCount", Convert.ToInt32(vSyncToggle.isOn));
                return;
            }
            vSyncToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("vSyncCount"));
            return;
        }
        PlayerPrefs.SetInt("vSyncCount", Convert.ToInt32(vSyncToggle.isOn));
        QualitySettings.vSyncCount = Convert.ToInt32(vSyncToggle.isOn);
        //Debug.Log("vSyncCount =" + PlayerPrefs.GetInt("vSyncCount"));
    }

    // Called when the volume slider is changed.
    public void VolumeHandler (bool isStart) {
        if (isStart)
        {
            if (!PlayerPrefs.HasKey("masterVolume"))
            {
                masterVolumeSlider.value = 10;
                PlayerPrefs.SetInt("masterVolume", Convert.ToInt32(masterVolumeSlider.value));
                return;
            }
            masterVolumeSlider.value = PlayerPrefs.GetInt("masterVolume");
            return;
        }
        PlayerPrefs.SetInt("masterVolume", Convert.ToInt32(masterVolumeSlider.value));
        AudioListener.volume = masterVolumeSlider.value / 10;
        //Debug.Log(PlayerPrefs.GetInt("masterVolume"));
    }

}