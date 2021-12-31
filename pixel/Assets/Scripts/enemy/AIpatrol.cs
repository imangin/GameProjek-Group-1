using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;

    public int Walkspeed = 70;
    private int Walk;
    private bool mustTurn;
    private bool Grounded;
    public Rigidbody2D r2d;
    public Transform GrounCheckPos;
    public LayerMask groundlayer;
    public Collider2D bodyCollider;
    public GameObject obj;
    public float distance = 0; //pham vi cho phep quai di chuyen
    private Animator HoatHoa;
    
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        distance += obj.transform.position.x;
        Grounded = true;
        Walk = Mathf.RoundToInt( Walkspeed * Time.deltaTime);
        HoatHoa = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            HoatHoa.SetInteger("Walk",Walk);
            HoatHoa.SetBool("Grounded", Grounded);
            Patrol();
        }
       
    }
    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(GrounCheckPos.position, 0.1f, groundlayer);
        }
    }
    //tuan tra
    void Patrol()
    {
        
        if (mustTurn || bodyCollider.IsTouchingLayers(groundlayer) || obj.transform.position.x >= distance) 
        {
            Flip();
        }
        r2d.velocity = new Vector2(Walkspeed * Time.fixedDeltaTime, r2d.velocity.y);
        Walk = Mathf.RoundToInt(Walkspeed * Time.deltaTime);
    }
    //Doi huong
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x*-1, transform.localScale.y);
        Walkspeed *= -1;
        mustPatrol = true;
    }
    //tuong tac mat dat
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            Grounded = true;
            
        }
        
    }
}
