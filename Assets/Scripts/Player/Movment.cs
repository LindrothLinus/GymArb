using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movmen : MonoBehaviour
{
    public float TopSpeed = 1f;
    public float AccelerationTime = 1f;
    private float Speed=0f;
    private Rigidbody2D RB;
    private float Horizontal;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AccelerationTime = AccelerationTime / 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Hastighet höger vänster 
        Horizontal = Input.GetAxisRaw("Horizontal");
        float Acceleration = TopSpeed / AccelerationTime;
        Speed = Mathf.MoveTowards(Speed, Horizontal * TopSpeed, Acceleration * Time.deltaTime);

        RB.velocity = new Vector2(Speed, RB.velocity.y);

    }
}
