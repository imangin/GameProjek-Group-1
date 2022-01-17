using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour { 
    [SerializeField] GameObject ShopPanel;
    public PlayerGetDamage Health;
    public PlayerCombat Dame;
    public CoinsScript coins;
    void Start()
    {
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGetDamage>();
        Dame = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        coins = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinsScript>();
        ShopPanel.SetActive(false);
    }

public void ShopMenu()
    {
        ShopPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resumeshop()
    {
        ShopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void BuyHP()
    {
        if (coins.coin >= 20)
        {
            coins.coin -= 20;
            Health.CurrentHeatlh += 20;
            if (Health.CurrentHeatlh > 100)
            {
                Health.CurrentHeatlh = 100;
            }
        }
    }
    public void BuyDame()
    {
        if (coins.coin >= 50)
        {
            coins.coin -= 50;
            Dame.attackDamage += 20;
            StartCoroutine(Items());
        }
    }
    IEnumerator Items()
    {
        yield return new WaitForSeconds(10);
       Dame.attackDamage = 10;

    }
}
