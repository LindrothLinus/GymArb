using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int Hp;
    public Rigidbody2D RB;
    public GameOver GO;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            GetComponent<Movmen>().enabled = false;
            GetComponent<GraplingHook>().enabled = false;
            GO.GameOverScreen();
        }
		else
		{
            GetComponent<Movmen>().enabled = true;
            GetComponent<GraplingHook>().enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        
        if (other.gameObject.CompareTag("Enemy") && RB.velocity.y>=0)
        {
            Hp--;
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Lava"))
		{
            Hp = 0;
		}
	}


}

