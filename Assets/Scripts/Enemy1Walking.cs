using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Walking : MonoBehaviour
{
    public Enemy1Walking2 ew;

    
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
        Debug.Log("i triigern");
        if (other.CompareTag("Player"))
        {
            ew.IsActive = true;          

        }

    }

	private void OnTriggerExit2D(Collider2D other)
	{
        if (other.CompareTag("Player"))
        {
            ew.IsActive = false;
        }
           
    }


}


