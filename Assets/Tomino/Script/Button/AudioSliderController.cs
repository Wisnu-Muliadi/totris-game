using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    public Slider volumeSlider;
    public static float volumeValue; 
    void Start()
    {
        // Berlangganan ke acara OnValueChanged slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
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
}