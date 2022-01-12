using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask PlayerLayer;
    public float attackrange = 0.5f;
    public int attackDamage;
    private bool hitPlayer;
   
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        attackDamage = 1;
        anim = GetComponent<Animator>();
        hitPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hitPlayer)
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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitPlayer = true;
        }      
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitPlayer = false;
        }
    }
}
