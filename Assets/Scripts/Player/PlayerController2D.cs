using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;

    // read by ExplodeOnCollision.cs
    public bool isSwinging = false;

    Rigidbody2D playerRb;
    Animator animator;
    DialogueRunner dialogueRunner;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueRunner.IsDialogueRunning) {
            return;
        }
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

    void StopSwinging() {
        isSwinging = false;
    }
}
