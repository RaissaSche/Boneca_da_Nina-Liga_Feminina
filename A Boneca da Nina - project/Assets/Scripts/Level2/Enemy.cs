﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int health = 5;
    private bool canBeHit = true;

    [SerializeField]
    [Range (0f, 3f)]
    public float hitCooldown = 2f;
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 pushBackForce;
    [Range (0f, 3f)]
    public float pushBackCooldown = 1f;
    private bool canBePushed = true;
    [SerializeField]
    private bool pushBackOnDefense;

    [SerializeField]
    private Blink blink;

    public bool maxVelocity = true;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        blink = GetComponent<Blink> ();
    }

    void Update () {
        if (blink != null) {
            if (canBeHit)
                blink.StopBlink ();
            else
                blink.StartBlink ();
        }
    }

    private void FixedUpdate () {
        if (maxVelocity && rb.velocity.magnitude >= 3f)
            rb.velocity = rb.velocity.normalized * 3f;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "PlayerAttack" && canBeHit) {
            Invoke ("ResetCanBeHit", hitCooldown);
            canBeHit = false;
            health--;
            SoundManager.instance.PlaySFXAtPosition (SoundManager.SFXType.ENEMY_HIT, transform.position, 0.8f);
            if (health <= 0) {
                Destroy (gameObject);
                return;
            } else if (pushBackForce != Vector2.zero && canBePushed)
                PushBack (other.transform);
        } else if (other.gameObject.tag == "PlayerDefense" && canBePushed && pushBackOnDefense) {
            PushBack (other.transform);
        }
    }

    private void ResetCanBeHit () {
        canBeHit = true;
    }

    private void ResetCanBePushed () {
        canBePushed = true;
    }

    private void PushBack (Transform other) {
        canBePushed = false;
        Invoke ("ResetCanBePushed", pushBackCooldown);
        if (transform.position.x >= other.parent.position.x)
            rb.AddForce (pushBackForce);
        else
            rb.AddForce (new Vector2 (-pushBackForce.x, pushBackForce.y));
    }
}