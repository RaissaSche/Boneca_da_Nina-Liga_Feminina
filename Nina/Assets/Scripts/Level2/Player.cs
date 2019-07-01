using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public event Action<Player> OnDied;

    private SoundManager soundManager;
    private bool isJumping = false;

    // Movement
    [Header ("Movement Attributes")]
    public Rigidbody2D rb;
    [SerializeField]
    [Range (0f, 10f)]
    private float moveSpeed = 3f;
    private float speedMultiplier = 1f;

    // Jump
    [Header ("Jump")]
    [SerializeField]
    [Range (1f, 100f)]
    private float jumpForce = 5f;

    // Use this for initialization
    void Start () {
        soundManager = SoundManager.instance;

        rb = GetComponent<Rigidbody2D> ();
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.CompareTag ("Ground")) {
            isJumping = false;
        }
    }

    // Update is called once per frame
    private void Update () {

        float h = Input.GetAxis ("Horizontal");
        if (h >= 0.1f)
            transform.localScale = Vector3.one;
        else if (h <= -0.1f)
            transform.localScale = new Vector3 (-1f, 1f, 1f);

        if (Input.GetAxis ("Horizontal") != 0f)
            Move ();
        if ((Input.GetButtonDown ("Jump") || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && !isJumping)
            Jump ();

        if (Input.GetMouseButtonDown (0)) {
            Move ();
        } else if (Input.GetMouseButtonDown (1)) {

        }
    }

    private void Move () {
        rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * moveSpeed * speedMultiplier, rb.velocity.y);
    }

    public void SetMoveSpeed (float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }

    public float GetMoveSpeed () {
        return moveSpeed;
    }

    private void Jump () {
        isJumping = true;
        rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
        soundManager.PlaySFX (SoundManager.SFXType.JUMP);
    }
}