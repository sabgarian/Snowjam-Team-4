using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeHandler : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mainMixer;
    // Start is called before the first frame update

    //vol is given from 0-1
    private void Start()
    {
        float db = PlayerPrefs.GetFloat("decibels");
        float vol = Mathf.Pow(10, db / 20);
        slider.value = vol;
    }

    public void convertToDB()
    {
        float vol = slider.value;
        float db = Mathf.Max(-80, 20 * Mathf.Log10(vol));
        PlayerPrefs.SetFloat("decibels", db);
        mainMixer.SetFloat("Volume", db);
    }
}
