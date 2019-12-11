using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static bool musicControllerExists;

    public AudioSource[] musicTracks;

    public int currentTrack;
    public bool musicCanPlay;
    // Start is called before the first frame update
    void Start()
    {
        if (!musicControllerExists)
        {
            musicControllerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        } else {
            musicTracks[currentTrack].Stop();
        }
    }

    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }

    public void PlayTrack(int newTrack)
    {
        musicTracks[newTrack].Play();
    }

    public void ResumeTrack(int newTrack)
    {
        musicTracks[newTrack].Stop();
        musicTracks[currentTrack].Play();
    }
}
