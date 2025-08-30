using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    public float movementSpeed, jumpForce;
    public bool isFacingRight, isJumping;
    Rigidbody2D rb;

    //GroundCheker
    public Transform groundChecker;
    public float radius;
    public LayerMask whatIsGround;

    //animation
    Animator anim;
    string walk_parameter = "walk";
    string idle_parameter = "idle";
    string land_parameter = "land";
    string jump_parameter = "jump";

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move*movementSpeed, rb.velocity.y);
        
        if (move > 0 && isFacingRight == false)
        {
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        }
        else if (move < 0 && isFacingRight == true)
        {
            transform.eulerAngles = Vector2.up * 180;
            isFacingRight = false;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround()) 
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (!IsGround() && !isJumping) 
        { 
            anim.SetTrigger(jump_parameter);
            isJumping = true;
        } else if(IsGround() && isJumping)
        {
            anim.SetTrigger(land_parameter);
            isJumping = false;
        }
    }

    bool IsGround()
    {
        return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundChecker.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HolyWater"))
        {
            GoalMenager.singleton.CollectHolyWater();
            Destroy(collision.gameObject);
        } else if (collision.CompareTag("Goal"))
        {
            print("CONGRATULATION!! YOU WIN:)");
        }
    }
}
