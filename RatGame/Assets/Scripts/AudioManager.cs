using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //public static float audioExposed { get; private set; }
    public AudioMixer masterMixer;

    public void setSFXLevel(float value) {
        masterMixer.SetFloat("audioExposed", value);
    }

    public void setMusicLevel(float value) {
        masterMixer.SetFloat("musicExposed", value);
    }

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
