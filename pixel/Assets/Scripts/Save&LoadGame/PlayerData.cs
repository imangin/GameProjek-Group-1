using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int Health;
    public int Coin;
    public int level;

    public PlayerData(PlayerGetDamage health)
    {
        Health = health.CurrentHeatlh;
    }
    public PlayerData(CoinsScript coin)
    {
        Coin = coin.coin;
    }
}
