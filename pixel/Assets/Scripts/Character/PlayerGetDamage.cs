using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    public int PlayerMaxHeatlh = 20;
    int CurrentHeatlh;
    private bool block;
    private Animator anim;
    void Start()
    {
        CurrentHeatlh = PlayerMaxHeatlh;
        anim = GetComponent<Animator>();
        block = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            block = true;
        }
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
            PlayerMaxHeatlh = CurrentHeatlh;
        }
    }
    void Die()
    {
        anim.SetBool("noBlood", false);
        anim.SetBool("Death", true);
        Debug.Log("Player die");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<move>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        
        this.enabled = false;
    }
}
