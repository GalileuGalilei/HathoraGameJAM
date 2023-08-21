using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManeger : MonoBehaviour
{
    [SerializeField] Slider slider;


    void Start()
    {
        if(!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume ()
    {
        AudioListener.volume = slider.value;
        Save();
    }

    private void Load ()
    {
        slider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    private void Save ()
    {
        PlayerPrefs.SetFloat("soundVolume", slider.value);
    }
}
