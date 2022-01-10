using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    public int PlayerMaxHeatlh = 3;
    int CurrentHeatlh;
    private Animator anim;
    void Start()
    {
        CurrentHeatlh = PlayerMaxHeatlh;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(int Damage)
    {
        CurrentHeatlh -= Damage;
        anim.SetTrigger("Hurt");
        Debug.Log("me Lost " + Damage);
        if (CurrentHeatlh <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("noBlood", false);
        anim.SetBool("Death", true);
        Debug.Log("Player die");
        //GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<move>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        this.enabled = false;
    }
}
