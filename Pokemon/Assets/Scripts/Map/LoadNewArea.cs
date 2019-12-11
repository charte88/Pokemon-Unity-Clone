using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string sceneToLoad;
    public string exitPoint;

    private Movement thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
