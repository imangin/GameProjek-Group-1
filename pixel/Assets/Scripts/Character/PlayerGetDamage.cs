using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerGetDamage : MonoBehaviour
{
    public int PlayerMaxHeatlh = 100;
   public int CurrentHeatlh;
    private bool block;
    private Animator anim;
    public Slider PlayerHealthSlider;
    void Start()
    {
        CurrentHeatlh = PlayerMaxHeatlh;
        anim = GetComponent<Animator>();
        block = false;
        PlayerHealthSlider.maxValue = 100;
        PlayerHealthSlider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            block = true;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            block = false;
        }
        PlayerHealthSlider.value = CurrentHeatlh;
    }
    public void TakeDamge(int Damage)
    {
        if (!block)
        {
            CurrentHeatlh -= Damage;
            anim.SetTrigger("Hurt");
            Debug.Log("me Lost " + Damage);
            if (CurrentHeatlh <= 0)
            {
                Die();

            }
        }
        if(block)
        {
            anim.ResetTrigger("Hurt");
           
        }
    }
    void Die()
    {
        anim.SetBool("noBlood", false);
        anim.SetBool("Death", true);
        anim.ResetTrigger("Hurt");
        Debug.Log("Player die");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<move>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(Menu());
        IEnumerator Menu()
        {
            yield return new WaitForSeconds((float)1.35);
            SceneManager.LoadScene("losescenes");
        }
        this.enabled = false;
    }
    public void Savegame()
    {
        SaveSystem.SavePlayerHealth(this);
    }
    public void Loadgame()
    {
        PlayerData data = SaveSystem.LoadPlayerHealth();
        CurrentHeatlh = data.Health;

    }
}
