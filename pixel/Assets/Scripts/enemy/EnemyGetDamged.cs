using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamged : MonoBehaviour
{
    public int EnemyMaxHeatlh = 6;
    int CurrentHeatlh;
    private Animator anim;
    public GameObject hitbox;
    public GameObject Triggerarea;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHeatlh = EnemyMaxHeatlh;
        anim = GetComponent<Animator>();
        Triggerarea = GameObject.FindGameObjectWithTag("triggerarea");
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
        hitbox.SetActive(false);
        Triggerarea.SetActive(false);
        this.enabled = false;
    }
}
