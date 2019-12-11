using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePokemon : MonoBehaviour
{
    public string PName;
    public Sprite image;
    public BiomeList biomeFound;
    public PokemonType type;
    public Rarity rarity;
    public int HP;
    public int maxHP;
    public int damage;
    public int defense;
    public int expToReceive;
    public Stat AttackStat;
    public Stat DefenseStat;

    public PokemonStats pokemonStats;

    public bool canEvolve;
    public PokemonEvolution evolveTo;

    public int level;


    // Start is called before the first frame update
    void Start()
    {
        //maxHP = HP;
    }

    public bool TakeDamage(int dmg)
    {
        int totalDamage = dmg - defense;
        HP -= totalDamage;

        if (HP <= 0)
            return true;
        else
            return false;
    }

    public void AddMember(BasePokemon bp)
    {
        this.PName = bp.PName;
        this.image = bp.image;
        this.biomeFound = bp.biomeFound;
        this.type = bp.type;
        this.rarity = bp.rarity;
        this.HP = bp.HP;
        Debug.Log("HP: " + HP);
        this.maxHP = bp.maxHP;
        this.HP = bp.maxHP;
        Debug.Log("MaxHP: " + maxHP);
        this.damage = bp.damage;
        this.AttackStat = bp.AttackStat;
        this.DefenseStat = bp.DefenseStat;
        this.pokemonStats = bp.pokemonStats;
        this.canEvolve = bp.canEvolve;
        this.evolveTo = bp.evolveTo;
        this.level = bp.level;
    }
}

public enum Rarity
{
    VeryCommon,
    Common,
    SemiRare,
    Rare,
    VeryRare
}

public enum PokemonType
{
    Flying,
    Ground, 
    Rock,
    Steel,
    Fire,
    Water,
    Grass,
    Ice,
    Electric,
    Psychic,
    Dragon,
    Dark,
    Fighting,
    Normal,
    Poison
}

[System.Serializable]

public class PokemonEvolution
{
    public BasePokemon nextEvolution;
    public int levelUpLevel;
}
[System.Serializable]
public class PokemonStats
{
    public int AttackStat;
    public int DefenseStat;
    public int SpAttackStat;
    public int SpDefenseStat;
    public int SpeedStat;
    public int EvasionStat;
}