using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinColection : MonoBehaviour
{
    public CoinManeger cm;



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
		if (other.gameObject.CompareTag("Hair"))
		{
            cm.CoinCount++;
            //Debug.Log("k�rs");
            Destroy(other.gameObject);
            
            
		}
	}
}
