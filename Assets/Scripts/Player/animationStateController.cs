using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{

    Animator animator;
    public Rigidbody playerRigidbody;


    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (playerRigidbody != null)
        {
            
            float velocityMagnitude = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y, playerRigidbody.velocity.z).magnitude;

            if (velocityMagnitude < 0.5f)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
            else if (velocityMagnitude >= 0.5f && velocityMagnitude < 10f)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
            }
            else if (velocityMagnitude >= 10f)
            {

                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
            }


        }
    }
}
