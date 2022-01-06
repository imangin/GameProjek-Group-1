using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public Transform raycast;
    public LayerMask RaycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer; //thoi gian delay don danh

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; //khoang cach giua ke thu va nhan vat
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;


    private void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
        anim.SetBool("canWalk", true);
    }
    void Update()
    {
      if(inRange)
        {
            hit = Physics2D.Raycast(raycast.position, Vector2.left, rayCastLength, RaycastMask);
            RaycastDebugger();
        }
      //Nguoi choi bi phat hien
      if(hit.collider != null)
        {
            Enemylogic();
        }
      else if(hit.collider == null)
        {
            inRange = false;
        }

      if (inRange == false)
        {
            //anim.SetBool("canWalk", false);
            StopAttack();
        }
    }
    void Enemylogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance > attackDistance)
        {
            Move();
            Debug.Log("Move");
            StopAttack();
        }
        else if(attackDistance > distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldow();
            anim.SetBool("attack", false);
        }
    }
    void Move()
    {
        anim.SetBool("canWalk", true);
        
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("attack", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Spin"))
        {
            Vector2 targetPosittion = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosittion, moveSpeed * Time.deltaTime);
        }
    }
    void Cooldow()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void StopAttack()
    {
        attackMode = false;
        anim.SetBool("attack", false);
        cooling = false;
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * rayCastLength, Color.green);
        }
    }
    public void TriggerCooling()
    {
        cooling =  true;
    }

}
