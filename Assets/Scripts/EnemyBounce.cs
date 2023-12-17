using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{
    public float BounceOnHold;
    public float DefaultBounce;
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Enemy"))
        {
            //if (RB.velocity.y <= 0)
            //{
                Destroy(other.gameObject);
                if (Input.GetButton("Jump"))
                {
                    RB.velocity = new Vector2(RB.velocity.x, BounceOnHold);
                }
                else
                {
                    RB.velocity = new Vector2(RB.velocity.x, DefaultBounce);
                }
                
            //}
        }
	}
}
