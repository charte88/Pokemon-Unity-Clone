using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject defendingPrefab;

    public Transform playerPodium;
    public Transform defendingPodium;

    public BattleState state;

    private static bool bsExists;

    // Start is called before the first frame update
    void Start()
    {
       /* if (!bsExists)
        {
            bsExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        } */
        //state = BattleState.Start;
        SetupBattle();
    }

    void SetupBattle()
    {
        Instantiate(playerPrefab, playerPodium);
        Instantiate(defendingPrefab, defendingPodium);
    }

    
}

