using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public float[] highScore = { -1, -1, -1 };
    public float musicVolume, effectVolume, mouseSensitivity;
    [SerializeField]
    Slider musicSlider, effectSlider, mouseSensitivitySlider;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(musicSlider)
        {
            musicVolume = musicSlider.value;
        }
        if(effectSlider)
        {
            effectVolume = effectSlider.value;
        }
        if(mouseSensitivitySlider)
        {
            mouseSensitivity = mouseSensitivitySlider.value;
        }
    }

}
