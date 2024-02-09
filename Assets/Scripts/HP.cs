using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HP : MonoBehaviour
{
    public int Hp;
    public Rigidbody2D RB;
    public GameOver GO;
    [SerializeField]LiveManeger LV;
    private int frames =30;
    private bool tookDamage=false;
    // Start is called before the first frame update
    void Start()
    {
        LV.LifeCount = Hp;
    }

	private void FixedUpdate()
	{
        if (tookDamage)
        {
            frames++;
        }


        if (frames > 100)
        {
            tookDamage = false;
            frames = 0;
        }
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
            //if (!(frames > 30)) return;
            if(tookDamage == false)
			{
                Hp--;
                LV.LifeCount--;
                tookDamage = true;
                frames = 0;
            }


            
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

