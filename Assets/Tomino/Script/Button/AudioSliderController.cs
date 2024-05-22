using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider SFXVolumeSlider;
    public static float volumeValue; 
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        SFXVolumeSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    public void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }
}