using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour {

    public int damage;
	public float damageRate;
	public float pushBackForce;

	float nextDamage;

	// Use this for initialization
	void Start () {
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
        // if(collision.CompareTag("Player"))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //     Debug.Log("Die");
        // }
    // }
	void OnTriggerStay2D(Collider2D other){
		if(other.tag=="Player" && nextDamage<Time.time){
			PlayerGetDamage thePlayerGetDamage = other.gameObject.GetComponent<PlayerGetDamage>();
			thePlayerGetDamage.TakeDamge(damage);
			nextDamage = Time.time + damageRate;

			pushBack(other.transform);
		}
	}

	void pushBack(Transform pushObject){
		Vector2 pushDirection = new Vector2(0, (pushObject.position.y - transform.position.y)).normalized;
		pushDirection*=pushBackForce;
		Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D>();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
	}
}
