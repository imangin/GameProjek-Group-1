using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    //public List<GameObject> TouchingObjects;
    public Transform attackPoint;
    public LayerMask PlayerLayer;
    public float attackrange = 0.5f;
    public int attackDamage;
    private bool hitPlayer;
    public GameObject hurtPlayer;
    private Animator anim;
    private int ptouch;
    // Start is called before the first frame update
    void Start()
    {
        //TouchingObjects = new List<GameObject>();
        ptouch = 0;
        anim = GetComponent<Animator>();
        hitPlayer = false;
        hurtPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        if (hitPlayer)
        {
            Attack();
        }
    }
    
    void Attack()
    {
        //phat hien ke thu trong tam danh
        //Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, PlayerLayer);

        ////gay sat thuong len ke thu
        //foreach (Collider2D Player in hitPlayer)
        //{
        //    Debug.Log("Hit " + Player.name);
        //    Player.GetComponent<PlayerGetDamage>().TakeDamge(attackDamage);

        //}
        //StartCoroutine(delay());
        //IEnumerator delay()
        //{
            hurtPlayer.GetComponent<PlayerGetDamage>().TakeDamge(attackDamage);
            //yield return new WaitForSeconds((float)0.5);
        //}
    }
    //private void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //        return;
    //    Gizmos.DrawWireSphere(attackPoint.position, attackrange);
    //}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ptouch == 0)
            {
                ptouch = 1;
                hitPlayer = true;
               
            }
            
        }
        //if (!TouchingObjects.Contains(other.gameObject))
        
        //    TouchingObjects.Add(other.gameObject);
        //Debug.Log("touching" + other.gameObject);
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
            if (ptouch == 1)
            {
                ptouch = 0;
                hitPlayer = false;
            }
        
        //if (TouchingObjects.Contains(other.gameObject))
        //    TouchingObjects.Remove(other.gameObject);
    }
    
}
