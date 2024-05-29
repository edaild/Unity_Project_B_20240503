using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixercontroller : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicMasterSlider;
    [SerializeField] private Slider musicBGMSlider;
    [SerializeField] private Slider musicSFXSlider;


    // 슬라이더 MinValue 0.001 사운드 볼륨은 Log10 단위로 되었기 때문에

    private void Awake()
    {
        // 마스터 슬라이더 값이 변경될때 리스너를 통해서 값을전달한다.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);

        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);

        musicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float volume)   // 마스터 볼륨 슬라이더가 Mixer에 반영되게
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);        // 볼륨은 Log10단위에 x20을 해준다.     
    }
    public void SetBGMVolume(float volume)  // BGM 볼륨 슬라이더가 Mixer에 반영되게
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)  // SFX 볼륨 슬라이더가 Mixer에 반영되게
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
