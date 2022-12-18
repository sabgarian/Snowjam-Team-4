using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerPrefsInit : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    // Start is called before the first frame update
    void Start()
    {
        mainMixer.SetFloat("Volume", PlayerPrefs.GetFloat("decibels"));
    }
}
