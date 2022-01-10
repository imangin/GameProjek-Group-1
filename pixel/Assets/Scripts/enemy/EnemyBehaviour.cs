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
    public Transform LeftLimit;
    public Transform RightLimit;

    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance; //khoang cach giua ke thu va nhan vat
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;


    private void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
        anim.SetBool("canWalk", true);
    }
    void Update()
    {
      if(!attackMode)
        {
            Move();
        }
      if(!InsideofLimit() && !inRange && !attackMode)
        {
            SelectTarget();
        }
      if(inRange)
        {
            hit = Physics2D.Raycast(raycast.position, transform.right, rayCastLength, RaycastMask);
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
        distance = Vector2.Distance(transform.position, target.position);
        if(distance > attackDistance)
        {
           
            
            StopAttack();
        }
        else if(attackDistance > distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldow();
            
            anim.SetBool("Attack 1", false);
        }
    }
    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector2 targetPosittion = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosittion, moveSpeed * Time.deltaTime);
        }
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack 1" , true);
        
    }
    void Cooldow()
    {
        Debug.Log("cooldow");
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    public void StopAttack()
    {
        attackMode = false;
        anim.SetBool("Attack 1", false);
        cooling = false;
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();
        }
    }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(raycast.position, transform.right * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(raycast.position, transform.right * rayCastLength, Color.green);
        }
    }
    public void TriggerCooling()
    {
        cooling =  true;
    }
    private bool InsideofLimit()
    {
        return transform.position.x > LeftLimit.position.x && transform.position.x < RightLimit.position.x;
    }
    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, LeftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, RightLimit.position);
        if (distanceToLeft > distanceToRight)
        {
            target = LeftLimit;
        }
        else
        {
            target = RightLimit;
        }
        Flip();

    }
    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
}
