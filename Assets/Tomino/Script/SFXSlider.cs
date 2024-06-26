using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    [SerializeField] string _settingName = "";
    void Start()
    {
        Slider slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(_settingName);
        slider.onValueChanged.AddListener(UpdateMusicVolume);
    }
    public void UpdateMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(_settingName, volume);
    }
}
