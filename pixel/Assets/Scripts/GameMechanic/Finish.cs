using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameObject health;
    private GameObject Coin;
   
  
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player");
        Coin = GameObject.FindGameObjectWithTag("Player");

    }
    public void Update()
    {
       
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Savegame();
            CompleteLevel();
                    
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }
    public void Loadgame()
    {
        //PlayerData data = SaveSystem.LoadPlayer();
        //Health = data.Health;
        //coin = data.Coin;
        //Health = health.CurrentHeatlh;
        //coin = Coin.coin;
        health.GetComponent<PlayerGetDamage>().Loadgame();
        Coin.GetComponent<CoinsScript>().Loadgame();
    }
    public void Savegame()
    {
        health.GetComponent<PlayerGetDamage>().Savegame();
        Coin.GetComponent<CoinsScript>().Savegame();
        //SaveSystem.SavePlayerHealth(health);
    }
}
