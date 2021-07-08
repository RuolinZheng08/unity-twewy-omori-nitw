using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 8.0f;

    Rigidbody2D playerRb;
    Animator animator;

    float horizontal;

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
        horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        animator.SetFloat("Speed", horizontal);

        // swing
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Swing");
            isSwinging = true;
        }
    }

    void FixedUpdate() {
        Vector2 position = playerRb.position;
        position.x += speed * horizontal * Time.deltaTime;
        playerRb.MovePosition(position);
    }

    void FinishSwinging() {
        isSwinging = false;
    }
}
