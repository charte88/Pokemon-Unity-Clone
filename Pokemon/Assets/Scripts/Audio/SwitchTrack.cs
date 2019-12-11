using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrack : MonoBehaviour
{
    private MusicController theMusicController;
    public int newTrack;

    public bool switchOnStart;
    // Start is called before the first frame update
    void Start()
    {
        theMusicController = FindObjectOfType<MusicController>();

        if (switchOnStart)
        {
            theMusicController.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theMusicController.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
