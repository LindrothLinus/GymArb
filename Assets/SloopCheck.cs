using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloopCheck : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] PhysicsMaterial2D PM;
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

    }
	private void OnCollisionEnter2D(Collision2D other)
	{
        if (other.gameObject.CompareTag("Ground") && 0 != Input.GetAxisRaw("Horizontal"))
        {
            PM.friction = 10000;
        }
        else
        {
            PM.friction = 0;
        }

    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        PM.friction = 0;
    }
}
