using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;

    Rigidbody2D characterRb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", horizontal);
        float moveBy = horizontal * speed;
        characterRb.velocity = new Vector2(moveBy, characterRb.velocity.y);
    }
}
