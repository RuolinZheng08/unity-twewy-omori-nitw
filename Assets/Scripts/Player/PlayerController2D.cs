using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 8.0f;

    Rigidbody2D playerRb;
    Animator animator;

    // read by ExplodeOnCollision.cs
    public bool isSwinging;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Swing();
    }

    void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", horizontal);
        float moveBy = horizontal * speed;
        playerRb.velocity = new Vector2(moveBy, playerRb.velocity.y);
    }

    void Swing() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Swing");
            isSwinging = true;
        }
    }

    void FinishSwinging() {
        isSwinging = false;
    }
}
