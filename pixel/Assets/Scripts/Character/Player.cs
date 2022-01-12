using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Player 
{
    private int _coin;
    private float _health;
    public Player() { }
    public Player(int coin, float health)
    {
        _coin = coin;
        _health = health;

    }
    public int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            _coin = value;
        }
    }
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
}//class
