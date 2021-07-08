using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    Animator animator;
    Rigidbody2D objectRb;

    // allow some time for the swing animation to complete
    float explodeAfterSeconds = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        objectRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D other) {
        PlayerController2D player = other.collider.GetComponent<PlayerController2D>();
        if (player != null && player.isSwinging) {
            StartCoroutine("PlayExplodeAnimation");
        }
    }

    IEnumerator PlayExplodeAnimation() {
        yield return new WaitForSeconds(explodeAfterSeconds);
        animator.SetTrigger("Explode");
        objectRb.simulated = false;
    }
}
