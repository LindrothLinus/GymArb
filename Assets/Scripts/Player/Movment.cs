using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movmen : MonoBehaviour
{
    public float TopSpeed = 1f;
    private float Speed = 0f;
    public float AccelerationTime = 1f;
    public float DecelerationTime = 1f;
    private float Horizontal;

    public float JumpHight = 1f;


    private Rigidbody2D RB;

    public Transform GroundCheck;
    public LayerMask Groundlayer;
    bool OnGround;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AccelerationTime = AccelerationTime / 10;
        DecelerationTime = DecelerationTime / 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Hastighet höger vänster 
        Horizontal = Input.GetAxisRaw("Horizontal");

        //om ingen iput från Horizontal
        if (Horizontal == 0)
        {
            //lägg på decelration
            float Deceleration = TopSpeed / DecelerationTime;
            Speed = Mathf.MoveTowards(Speed, 0, Deceleration * Time.deltaTime);
        }
        else
        {
            // If there is input, accelerate the character
            float Acceleration = TopSpeed / AccelerationTime;
            Speed = Mathf.MoveTowards(Speed, Horizontal * TopSpeed, Acceleration * Time.deltaTime);
        }
        

        RB.velocity = new Vector2(Speed, RB.velocity.y);

        OnGround = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.28f, 0.09f),CapsuleDirection2D.Horizontal,0,Groundlayer);

		if (Input.GetButtonDown("Jump")&& OnGround)
		{
            //RB.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);
            RB.velocity = new Vector2(RB.velocity.x , JumpHight);
		}




    }
}
