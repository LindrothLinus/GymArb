using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movmen : MonoBehaviour
{

    //Moving vars
    public float TopSpeed = 1f;
    private float Speed = 0f;
    public float AccelerationTime = 1f;
    public float DecelerationTime = 1f;
    private float Horizontal;

    


    private Rigidbody2D RB;


    //Jumping vars
    public float JumpHight = 1f;
    public Transform GroundCheck;
    public LayerMask Groundlayer;
    bool OnGround;

    bool IsJumping;
    float Jumpcounter;
    Vector2 VecGreavity;
    public float JumpMultiplayer;
    public float JumpTime;
    public float FallSpeed= 1;

	//Cayouty jump var
	float CayoteJump = 0.2f;
    float CayoteTime;

    //Animation
    public Animator animator;
    private bool isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AccelerationTime = AccelerationTime / 10;
        DecelerationTime = DecelerationTime / 10;

        VecGreavity = new Vector2(0, -Physics2D.gravity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //---------------Hastighet höger vänster ---------------------------------------
        Horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));

        //om ingen iput från Horizontal
        if (Horizontal == 0)
        {
            //lägg på decelration
            float Deceleration = TopSpeed / DecelerationTime;
            Speed = Mathf.MoveTowards(Speed, 0, Deceleration * Time.deltaTime);
        }
        else
        {

            //ifall man trycker på något accelerera 
            float Acceleration = TopSpeed / AccelerationTime;
            Speed = Mathf.MoveTowards(Speed, Horizontal * TopSpeed, Acceleration * Time.deltaTime);
        }
        

        RB.velocity = new Vector2(Speed, RB.velocity.y);

        OnGround = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.28f, 0.09f),CapsuleDirection2D.Horizontal,0,Groundlayer);






		//--------------------------Hopp----------------------------

        //Cayoty
		if (OnGround)
		{
            CayoteTime = CayoteJump;
            animator.SetBool("IsJumping", false);
		}
		else
		{
            CayoteTime -= Time.deltaTime;
		}



        //test


        
        //Själva hopp
        if (Input.GetButtonDown("Jump") && CayoteTime>0f)
        {
            RB.velocity = new Vector2(RB.velocity.x, JumpHight);
            IsJumping = true;
            Jumpcounter = 0;
            
        }
		if (Input.GetButtonUp("Jump"))
		{
            CayoteTime = 0f;
            

        }

        if (IsJumping)
        {
            animator.SetBool("IsJumping", true);
            if (Input.GetButtonUp("Jump") && RB.velocity.y > 0)
            {
                // Reduce the upward velocity when the jump button is released
                RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y * 0.5f);
            }

            Jumpcounter += Time.deltaTime;
            if (Jumpcounter > JumpTime)
            {
                IsJumping = false;
            }
            else
            {
                RB.velocity += Vector2.up * VecGreavity * JumpMultiplayer * Time.deltaTime;
            }
        }
        

        //Fall speed
		if (RB.velocity.y < 0) 
		{
            RB.velocity -= VecGreavity*FallSpeed* Time.deltaTime;
		}




        //Flipa spriten
        if (Horizontal> 0.1f && !isFacingRight)
        {
            Flip();
        }
        else if (Horizontal < -0.1f && isFacingRight)
        {
            Flip();
        }


    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }



}
