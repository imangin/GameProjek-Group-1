using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveAndHit : MonoBehaviour
{
    private bool Grounded = true;
    private bool QuayPhai = true;
    public float VanToc = 165f;
    public float Speed;
    public int Walk;
    private Rigidbody2D r2d;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetInteger("Walk", Walk);
        Anim.SetBool("Grounded", Grounded);
    }
    private void FixedUpdate()
    {
        
    }
    void DiChuyen()
    {
        float PhimNhanPhaiTrai = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        r2d.velocity = new Vector2(VanToc * PhimNhanPhaiTrai, r2d.velocity.y);
        Walk = Mathf.RoundToInt(VanToc * PhimNhanPhaiTrai);
        if (PhimNhanPhaiTrai > 0 && !QuayPhai) HuongMatSlime();
        if (PhimNhanPhaiTrai < 0 && QuayPhai) HuongMatSlime();

    }
    void HuongMatSlime()
    {
        QuayPhai = !QuayPhai;
        Vector2 HuongQuay = transform.localScale;
        HuongQuay.x *= -1;
        transform.localScale = HuongQuay;
    }
}
