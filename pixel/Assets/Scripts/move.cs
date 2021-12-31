using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float VanToc = 165f;
    public int AnimState;
    private bool Grounded = true;
    private bool QuayPhai =true;
    private bool canAttack;
    private bool IdleBlock = false;
    public float NhayCao = 1800;
    private Rigidbody2D r2d;
    private int attackTime = 0;
    private Animator HoatHoa;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        HoatHoa = GetComponent<Animator>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        HoatHoa.SetInteger("AnimState", AnimState);
        HoatHoa.SetBool("Grounded", Grounded);
        NhayLen();
        Tancong();
        Block();
        HoatHoa.SetBool("IdleBlock", IdleBlock);

    }
    private void FixedUpdate()
    {
        DiChuyen();
        
    }
    void DiChuyen()
    {
        float PhimNhanPhaiTrai = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;     
        r2d.velocity = new Vector2(VanToc * PhimNhanPhaiTrai, r2d.velocity.y );
        AnimState = Mathf.RoundToInt(VanToc * PhimNhanPhaiTrai);
        if (PhimNhanPhaiTrai > 0 && !QuayPhai) HuongMatHero();
        if (PhimNhanPhaiTrai < 0 && QuayPhai)  HuongMatHero();
        
    }
    void HuongMatHero()
    {
        QuayPhai = !QuayPhai;
        Vector2 HuongQuay = transform.localScale;
        HuongQuay.x*= -1;
        transform.localScale = HuongQuay;
    }
    void NhayLen()
    {

        float fall = r2d.velocity.y;
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            r2d.AddForce((Vector2.up) * NhayCao);
            
        }
        if (fall > 1)
        {
            HoatHoa.SetTrigger("Jump");
            Grounded = false;
        }
        if (fall<1 && Grounded == false)
        {
            HoatHoa.ResetTrigger("Jump");
            
            HoatHoa.SetFloat("AirSpeedY", fall);
        }
        
    }
    void Tancong()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            canAttack = false;
            attackTime++;
            StartCoroutine(attackDelay());
            if (attackTime == 1)
            {
                HoatHoa.SetTrigger("Attack1");
                
            }
            else if (attackTime == 2)
            {
                HoatHoa.SetTrigger("Attack2");
            }
            else if (attackTime == 3)
            {
                HoatHoa.SetTrigger("Attack3");
                attackTime = 0;
            }
           
        }
    }
    void Block()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            HoatHoa.SetTrigger("Block");
            if (Input.GetKey(KeyCode.F))
            {
                IdleBlock = true;
                VanToc = 0;
            }         
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            IdleBlock = false;
            VanToc = 165f;
        }
    }
    IEnumerator attackDelay() // thoi gian delay giua moi lan tan cong
    {
        yield return new WaitForSeconds(0.3f);
        canAttack = true;
    }
    private void OnCollisionEnter2D(Collision2D other) //xu ly va cham voi mat dat
    {
        if (other.gameObject.tag == "ground")
        {
            Grounded = true;
        }
    }
}
