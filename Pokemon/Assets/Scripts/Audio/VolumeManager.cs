using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public VolumeController[] volumeControllerObjects;

    public float currentVolumeLevel;
    public float maxVolumeLevel = 1.0f;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeControllerObjects = FindObjectsOfType<VolumeController>();

        if (currentVolumeLevel > maxVolumeLevel)     
            currentVolumeLevel = maxVolumeLevel;
        
        for (int i=0; i<volumeControllerObjects.Length; i++)
            volumeControllerObjects[i].SetAudioLevel(currentVolumeLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolumeSlider()
    {
        Start();
    }
}
