using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, DEFENDINGTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    private MusicController theMusicController;

    public GameObject playerCamera;
    public GameObject battleCamera;

    public BattleHud playerHUD;
    public BattleHud defendingHUD;

    public GameObject yourPokemon;
    public GameObject emptyPokemon;

    BasePokemon playerPokemon;
    BasePokemon defendingPokemon;

    private Player player;

    public GameObject playerObject;
    private GameObject dPokemon;

    public List<BasePokemon> allPokemon = new List<BasePokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();

    public Transform defensePodium;
    public Transform attackPodium;

    public Text dialogueText;

    private int expToReceive;
    private static bool gmExists;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
       /* if (!gmExists)
        {
          gmExists = true;
          DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
          Destroy(gameObject);
        } */
        playerCamera = GameObject.Find("Main Camera");
        battleCamera = GameObject.Find("BattleCamera");
        playerObject = GameObject.Find("Player");

        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
        theMusicController = FindObjectOfType<MusicController>();
    }

    public IEnumerator EnterBattle(Rarity rarity)
    {
        theMusicController.SwitchTrack(2);
        state = BattleState.START;

        playerObject.GetComponent<Movement>().isAllowedToMove = false;

        playerCamera.SetActive(false);
        battleCamera.SetActive(true);
        

        GameObject playerGo = Instantiate(yourPokemon, attackPodium);
        playerPokemon = playerGo.GetComponent<BasePokemon>();
        defendingPokemon = GetRandomPokemonFromList(GetPokemonByRarity(rarity));
        Debug.Log(defendingPokemon.name);

        

        dPokemon = Instantiate(emptyPokemon, defensePodium.transform.position, Quaternion.identity) as GameObject;
        Vector3 pokemonLocalPosition = new Vector3(0, 1, 0);
        dPokemon.transform.parent = defensePodium;
        dPokemon.transform.localPosition = pokemonLocalPosition;
  
        BasePokemon tempPokemon = dPokemon.AddComponent<BasePokemon>() as BasePokemon;
        tempPokemon.AddMember(defendingPokemon);

        dPokemon.GetComponent<SpriteRenderer>().sprite = defendingPokemon.image;
        dialogueText.text = "A wild " + defendingPokemon.PName + " approaches";

        playerHUD.SetHUD(playerPokemon);
        defendingHUD.SetHUD(tempPokemon);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
        //bm.ChangeMenu(BattleMenu.Selection);

    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action: ";
    }

    IEnumerator PlayerAttack()
    {
        // Damage the enemy
        dialogueText.text = playerPokemon.PName + " used Thunderbolt!";
        theMusicController.PlayTrack(4);
        yield return new WaitForSeconds(3f);

        bool isDead = defendingPokemon.TakeDamage(playerPokemon.damage);
        defendingHUD.SetHP(defendingPokemon.HP);
        yield return new WaitForSeconds(2f);

        // Check if the defending pokemon fainted
        // Change the state 

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        } else
        {
            state = BattleState.DEFENDINGTURN;
            StartCoroutine(DefendingTurn());
        }
    }

    IEnumerator DefendingTurn()
    {
        dialogueText.text = defendingPokemon.PName + " used an attack!";
        theMusicController.PlayTrack(5);
        yield return new WaitForSeconds(2f);
        
        bool isDead = playerPokemon.TakeDamage(defendingPokemon.damage);
        playerHUD.SetHP(playerPokemon.HP);
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator Flee()
    {
        dialogueText.text = "You got away safely!";
        theMusicController.PlayTrack(6);
        yield return new WaitForSeconds(1f);

        SwitchBackToWorld();
        //playerCamera.SetActive(true);
        //battleCamera.SetActive(false);
        //playerObject.GetComponent<Movement>().isAllowedToMove = true;
        //Destroy(dPokemon);
        //theMusicController.SwitchTrack(1);
    }

    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Wild " + defendingPokemon.PName + " has fainted!";
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "Your " + playerPokemon.PName + "has fainted!";
        }
        theMusicController.SwitchTrack(3);
        yield return new WaitForSeconds(6f);

        expToReceive = defendingPokemon.expToReceive;
        Debug.Log("Total EXP: " + expToReceive);
        dialogueText.text = "Your Ash's Pikachu got " + expToReceive + " Exp. points!";
        //player.ResolveCombat(expToReceive);

        yield return new WaitForSeconds(3f);

        SwitchBackToWorld();
        //playerCamera.SetActive(true);
        //battleCamera.SetActive(false);
        //playerObject.GetComponent<Movement>().isAllowedToMove = true;
        //Destroy(dPokemon);
        //theMusicController.SwitchTrack(1);
    }

    public void onFight()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());

    }

    public void onBag()
    {

    }

    public void onPokemon()
    {

    }

    public void onRun()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(Flee());
    }

    private void SwitchBackToWorld()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
        playerObject.GetComponent<Movement>().isAllowedToMove = true;
        Destroy(dPokemon);
        theMusicController.SwitchTrack(1);
    }

    public List<BasePokemon> GetPokemonByRarity(Rarity rarity)
    {
        List<BasePokemon> returnPokemon = new List<BasePokemon>();
        foreach (BasePokemon Pokemon in allPokemon)
        {
            if (Pokemon.rarity == rarity)
                returnPokemon.Add(Pokemon);
        }

        return returnPokemon;
    }

    public BasePokemon GetRandomPokemonFromList(List<BasePokemon> pokeList)
    {
        BasePokemon poke = new BasePokemon();
        int pokeIndex = Random.Range(0, pokeList.Count - 1);
        poke = pokeList[pokeIndex];
        return poke;
    }
}

[System.Serializable]
public class PokemonMoves
{
    string Name;
    public MoveType category;
    public Stat moveStat;
    public PokemonType moveType;
    public int PP;
    public float power;
    public float accuracy;

}
[System.Serializable]
public class Stat
{
    public float minimum;
    public float maximum;
}

public enum MoveType
{
    Physical,
    Special,
    Status
}
