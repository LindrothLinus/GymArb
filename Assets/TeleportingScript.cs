using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingScript : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Teleport;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
            Player.transform.position = Teleport.transform.position;
		}
	}
}
