using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloopCheck : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] PhysicsMaterial2D PM;
    float Horizontal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
			if (Horizontal == 0)
			{
                RB.velocity = new Vector2(0f,0);
			}
        }
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
            PM.friction = 0.1f;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
            PM.friction = 0;
		}
	}


}
