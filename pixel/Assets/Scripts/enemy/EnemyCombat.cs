using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask PlayerLayer;
    public float attackrange = 0.5f;
    public int attackDamage;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        attackDamage = 1;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Attack();
        }
    }
    void Attack()
    {
        //phat hien ke thu trong tam danh
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, PlayerLayer);

        //gay sat thuong len ke thu
        foreach (Collider2D Player in hitPlayer)
        {
            Player.GetComponent<PlayerGetDamage>().TakeDamge(attackDamage);

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
    }
   
}
