using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public float attackrange = 0.5f;
    public int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        attackDamage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    void Attack()
    {
        //phat hien ke thu trong tam danh
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayer);

        //gay sat thuong len ke thu
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyGetDamged>().TakeDamge(attackDamage);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
    }
}
