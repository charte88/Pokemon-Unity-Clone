using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int totalExp;

    //public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();
    // Start is called before the first frame update
    void Start()
    {
 
    }
    public void ResolveCombat(int exp)
    {
        Debug.Log("EXP earned: " + exp);
        Debug.Log("total EXP: " + totalExp);
        totalExp = totalExp + exp;
        Debug.Log("total EXP: " + totalExp);
    }
}
//[System.Serializable]
//public class OwnedPokemon {
  //  public string NickName;
    //public BasePokemon pokemon;
    //public int Level;
    //public List<PokemonMoves> moves = new List<PokemonMoves>();
//}
