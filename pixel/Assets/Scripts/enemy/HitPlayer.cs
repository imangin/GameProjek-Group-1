using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private bool hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
        hitPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {    
           if (other.gameObject.tag == "Player")
            {
                hitPlayer = true;
            } 
    }
}
