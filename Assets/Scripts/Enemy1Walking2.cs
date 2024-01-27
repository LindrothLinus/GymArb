using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Walking2 : MonoBehaviour
{

    public bool IsActive = false;
    public Transform Player;
    Rigidbody2D RB;
    Vector2 MoveDirection;
    [SerializeField] float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive == true)
		{
            Vector2 direction = (Player.position - transform.position).normalized;
            MoveDirection = direction;

            RB.velocity = new Vector2(MoveDirection.x * movespeed, RB.velocity.y);
            /*
            transform.LookAt(Player);

            transform.position += transform.forward * 5 * Time.deltaTime;
            */
        }
        
		if (RB.velocity.y > 0)
		{
            RB.velocity = new Vector2(RB.velocity.x,0);
		}
    }
}
