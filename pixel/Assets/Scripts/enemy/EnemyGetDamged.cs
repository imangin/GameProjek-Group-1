using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamged : MonoBehaviour
{
    public int EnemyMaxHeatlh = 2;
    int CurrentHeatlh;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHeatlh = EnemyMaxHeatlh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(int Damage)
    {
        CurrentHeatlh -= Damage;

        if (CurrentHeatlh <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("enemy die");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<AIpatrol>().enabled = false;
        this.enabled = false;
    }
}
