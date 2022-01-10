using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamged : MonoBehaviour
{
    public int EnemyMaxHeatlh = 2;
    int CurrentHeatlh;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHeatlh = EnemyMaxHeatlh;
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
        Debug.Log("enemy Lost " + Damage);
        if (CurrentHeatlh <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GetComponent<EnemyBehaviour>().StopAttack();
        anim.SetBool("Dead", true);
       
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<EnemyBehaviour>().enabled = false;
        GetComponent<EnemyGetDamged>().enabled = false;


        this.enabled = false;
    }
}
