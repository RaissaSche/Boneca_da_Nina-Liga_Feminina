using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool maxVelocity = true;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
    private void FixedUpdate()
    {
        if (maxVelocity && rb.velocity.magnitude >= 3f)
            rb.velocity = rb.velocity.normalized * 3f;
    }
}
