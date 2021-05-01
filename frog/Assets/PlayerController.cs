using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpingForwardSpeed;
    public float jumpForce;
    private Animator anim;
    private Rigidbody2D myRigidBody;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = transform.position.y <= 0;
        
        if (!isGrounded) {
            myRigidBody.velocity = new Vector2(jumpingForwardSpeed, myRigidBody.velocity.y);
        }
        else {
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        }
        
        
        if (Input.GetAxisRaw("Vertical") > 0.5) {
            if (isGrounded) {
                Debug.Log("eheeee");
                myRigidBody.velocity = new Vector2(jumpingForwardSpeed, jumpForce);
                SoundManager.Instance.PlaySound(soundEffects.croak);
            }
            
            
        }

        anim.SetFloat("Speed", myRigidBody.velocity.x);
        anim.SetBool("isGrounded", isGrounded);
    }
}
