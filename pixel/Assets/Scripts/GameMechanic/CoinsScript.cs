using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsScript : MonoBehaviour

{
   public int coin = 0;
    public TextMeshProUGUI textCoins;

    private void FixedUpdate()
    {
        textCoins.text = coin.ToString();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "coin")
        {
            coin ++;
            textCoins.text = coin.ToString();
            Destroy(other.gameObject);
        
        }
        
    }
    public void Savegame()
    {
        SaveSystem.SavePlayerCoin(this);
    }
    public void Loadgame()
    {
        PlayerData data = SaveSystem.LoadPlayerCoin();
        coin = data.Coin;

    }
}