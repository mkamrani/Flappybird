using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField ]float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    float maxY = 100f;


    // Use this for initialization
	void Start ()
	{
	    rb2d = GetComponent<Rigidbody2D>();
	    anim = GetComponent<Animator>();


	    maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, 230, 0)).y;
	    Debug.Log("maxY: " + maxY);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update...");
	    if (!isDead)
	    {
	        if (Input.GetMouseButtonDown(0)) // Left click
	        {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));

	            var position = transform.position;

                //Debug.Log("pos before: " + position);

	            if (position.y > maxY)
	            {
	                position.y = maxY;
	                Debug.Log("pos after: " + position);
	            }

	            transform.position = position;


                anim.SetTrigger("Flap");
	        }
	    }
	}

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
