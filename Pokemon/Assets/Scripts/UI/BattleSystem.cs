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

    // Start is called before the first frame update
    void Start()
    {
        //state = BattleState.Start;
        SetupBattle();
    }

    void SetupBattle()
    {
        Instantiate(playerPrefab, playerPodium);
        Instantiate(defendingPrefab, defendingPodium);
    }

    
}

