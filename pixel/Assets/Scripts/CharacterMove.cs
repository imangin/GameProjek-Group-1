using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float characterMove;
    GameObject obj;
    private Animator anim;
    public GameObject GroundController;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        anim.SetInteger("AnimState", 0);
        anim.SetBool("Grounded", true);
        GroundController = GameObject.FindGameObjectWithTag("GroundCollider");
        characterMove = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (Input.GetKey(KeyCode.D))
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(characterMove, 0));
            anim.SetInteger("AnimState", Mathf.RoundToInt(obj.GetComponent<Rigidbody2D>().velocity.x));
            
        }
        
        else if (Input.GetKey(KeyCode.A)) 
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-characterMove, 0));
            anim.SetInteger("AnimState", Mathf.RoundToInt(obj.GetComponent<Rigidbody2D>().velocity.x));
            
        }
        else if  (Input.GetKey(KeyCode.W))
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20));
            anim.SetTrigger("Jump");
            if(Input.GetKeyUp(KeyCode.W))
            {
                anim.ResetTrigger("Jump");
                anim.SetFloat("AirSpeedY", obj.GetComponent<Rigidbody2D>().velocity.y);
               
            }
        }
        else
        {
            
            anim.SetInteger("AnimState", 0);
        }
    }
    void OnCollisionEnter2D(Collision2D Ground)
    {
        
        
    }

}
