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
    public bool isSwinging;
    private Tongue tongue;
    public bool isLanding;

    private Quaternion prevRotation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        tongue = GetComponentInChildren<Tongue>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isLanding = myRigidBody.rotation != 0;

        if(isLanding && !isSwinging) {
           myRigidBody.MoveRotation(Quaternion.identity);
           
        }
        
        isGrounded = transform.position.y <= 0;
        
        if (isSwinging) {
            //Debug.Log(myRigidBody.rotation);
        }
        else if (!isGrounded) {
            myRigidBody.velocity = new Vector2(jumpingForwardSpeed, myRigidBody.velocity.y);
        }
        else {
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        }

        anim.SetFloat("Speed", myRigidBody.velocity.x);
        anim.SetBool("isGrounded", isGrounded);
    }

    public void GameOver(bool gameOver) {
        anim.SetBool("isGameOver",gameOver);
        transform.rotation = Quaternion.Euler(0,0,166);
    }

    public void Jump() {
        if (isGrounded) {
            myRigidBody.velocity = new Vector2(jumpingForwardSpeed, jumpForce);
            SoundManager.Instance.PlaySound(soundEffects.croak);
        }
        if (isSwinging) {
            myRigidBody.velocity = new Vector2(jumpingForwardSpeed, jumpForce);
            connectTongue(false);
            SoundManager.Instance.PlaySound(soundEffects.croak);
        }
    }

    public void ShootTongue() {
        connectTongue(!isGrounded && !isSwinging);
    }

    void connectTongue(bool connect) {
        tongue.Connect(connect);
        isSwinging = connect;
        prevRotation = transform.rotation;
    }
    
}
