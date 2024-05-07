using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider SFXVolumeSlider;
    public static float volumeValue; 
    void Start()
    {
        // Berlangganan ke acara OnValueChanged slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        SFXVolumeSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    public void ChangeVolume(float volume)
    {
        volumeValue = volume; 
        // Akses singleton GameManager dan sesuaikan volume sumber audio
        GameManager gameManager = GameManager.instance;

        if (gameManager != null && gameManager.audioSource != null)
        {
            gameManager.audioSource.volume = volume;
        }
    }

    public void ChangeSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);

    }
}