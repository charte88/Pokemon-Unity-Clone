using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource playerCollide;
    //public AudioSource playerConfirm;
    // Start is called before the first frame update
    private static bool sfxmanagerExists;
    void Start()
    {
        if (!sfxmanagerExists)
        {
            sfxmanagerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
