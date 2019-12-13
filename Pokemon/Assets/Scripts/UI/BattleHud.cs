using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text PName;
    public Text level;
    public Slider hpSlider;

    private static bool HUDExists;

    public void SetHUD(BasePokemon pokemon)
    {
        PName.text = pokemon.PName;
        level.text = "Lv " + pokemon.level;
        hpSlider.maxValue = pokemon.maxHP;
        hpSlider.value = pokemon.HP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;

    }

    void Start()
    {
      /*  if (!HUDExists)
        {
            HUDExists = true;
            DontDestroyOnLoad(transform.gameObject);
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(gameObject);
        }*/
    }
}
